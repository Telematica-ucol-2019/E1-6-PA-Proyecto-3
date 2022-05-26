using Bogus;
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
        public ObservableCollection<Pelicula> Peliculas{ get; set; }
        public ICommand cmdAgregarPelicula { get; set; }
        public ICommand cmdModificarPelicula { get; set; }
        public ICommand cmdAgregarProductora { get; set; }
        public PrincipalViewModel()
        {
            #region Propiedades
            Peliculas = new ObservableCollection<Pelicula>();
            #endregion
            #region Comandos
            cmdAgregarPelicula = new Command(() => cmdAgregarPeliculaMetodo());
            cmdModificarPelicula = new Command<Pelicula>((item) => cmdModificarMovieMetodo(item));
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

            App.Current.MainPage.Navigation.PushAsync(new DetallesPelicula(pelicula));
        }
        private void cmdModificarMovieMetodo(Pelicula pelicula)
        {
            App.Current.MainPage.Navigation.PushAsync(new DetallesPelicula(pelicula));
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