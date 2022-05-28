﻿using Bogus;
using Peliculas.Models;
using Peliculas.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Peliculas.ViewModels
{
    public class PrincipalViewModel : BaseViewModel
    {
        public ObservableCollection<Pelicula> Peliculas { get; set; }
        public ICommand cmdAgregarPelicula { get; set; }
        public ICommand cmdModificarPelicula { get; set; }
        public ICommand cmdVerActores { get; set; }
        public ICommand cmdVerTodosLosActores { get; set; }
        public ICommand cmdAgregarProductora { get; set; }
        public PrincipalViewModel()
        {
            #region Propiedades
            Peliculas = new ObservableCollection<Pelicula>();
            #endregion
            #region Comandos
            cmdAgregarPelicula = new Command(() => cmdAgregarPeliculaMetodo());
            cmdModificarPelicula = new Command<Pelicula>((item) => cmdModificarPeliculaMetodo(item));
            cmdVerActores = new Command<Pelicula>((item) => cmdVerActoresMetodo(item));
            cmdVerTodosLosActores = new Command(() => cmdVerTodosLosActoresMetodo());
            //cmdAgregarProductora = new Command(() => cmdAgregarProductoraMetodo);
            #endregion

        }
        #region Metodos
        //private void cmdAgregarProductoraMetodo(Productora productora)
        //{
        //    Productora productora = new Faker<Productora>()
        //        .RuleFor(c => c.Avatar, f => f.Person.Avatar);


        //    App.Current.MainPage.Navigation.PushAsync(new DetallesGeneral(productora));
        //}
        private void cmdAgregarPeliculaMetodo(Pelicula pelicula)
        {
            App.Current.MainPage.Navigation.PushAsync(new DetallesPelicula(pelicula));
        }
        private void cmdAgregarPeliculaMetodo()
        {
            Pelicula pelicula = new Faker<Pelicula>()
                .RuleFor(c => c.Portada, f => f.Person.Avatar);
            pelicula.Productora = new Faker<Productora>()
                .RuleFor(c => c.Nombre, f => f.Company.CompanyName());
            pelicula.Actores = new ObservableCollection<Actor>();
            //pelicula.Actores.Add(
            //    new Actor()
            //    {
            //        Id = 1,
            //        Nombre = "Jesús Iván",
            //        Alias = "iVan21",
            //        Peliculas = new ObservableCollection<Pelicula>()
            //        {
            //            pelicula
            //        }
            //    }
            //);
            for (int i = 0; i < 3; i++)
            {
                pelicula.Actores.Add(
                    new Faker<Actor>()
                        .RuleFor(c => c.Nombre, f => f.Name.FirstName())
                        .RuleFor(c => c.Alias, f => f.Name.LastName())
                );
            }
            App.Current.MainPage.Navigation.PushAsync(new DetallesPelicula(pelicula));
        }
        private void cmdModificarPeliculaMetodo(Pelicula pelicula)
        {
            App.Current.MainPage.Navigation.PushAsync(new DetallesPelicula(pelicula));
        }
        private void cmdVerActoresMetodo(Pelicula pelicula)
        {
            App.Current.MainPage.Navigation.PushAsync(new DetallesActores(pelicula));
        }
        private void cmdVerTodosLosActoresMetodo()
        {
            App.Current.MainPage.Navigation.PushAsync(new DetallesActores());
        }
        public void GetAll()
        {
            if (Peliculas != null)
            {
                Peliculas.Clear();
                App.PeliculasDb.GetAll().ForEach(item => Peliculas.Add(item));
            }
            else
            {
                Peliculas = new ObservableCollection<Pelicula>(App.PeliculasDb.GetAll());

            }
            OnPropertyChanged();
        }
        #endregion
    }
}