using Peliculas.Models;
using Peliculas.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Peliculas.ViewModels
{
    public class ListaActoresViewModel : BaseViewModel
    {
        public ObservableCollection<Actor> Actores { get; set; }
        public Pelicula Pelicula { get; set; }
        public ICommand cmdVerPeliculas { get; set; }
        public bool BotonDePeliculasVisible { get; set; }
        public ListaActoresViewModel(Pelicula pelicula)
        {
            Pelicula = pelicula;
            Actores = pelicula.Actores;
            BotonDePeliculasVisible = false;
            cargarElementos();
        }
        public ListaActoresViewModel()
        {
            Actores = new ObservableCollection<Actor>(App.ActoresDb.GetAll());
            BotonDePeliculasVisible = true;
            cargarElementos();
        }
        private void cargarElementos()
        {
            #region Propiedades
            #endregion
            #region Comandos
            cmdVerPeliculas = new Command<Actor>((item) => cmdVerPeliculasMetodo(item));
            #endregion
        }
        #region Metodos
        private async void cmdVerPeliculasMetodo(Actor actor)
        {
            await App.Current.MainPage.Navigation.PushAsync(new ListaPeliculas(actor));
        }
        #endregion
    }
}