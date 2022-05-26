using Peliculas.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Peliculas.ViewModels
{
    public class DetallesViewModel
    {
        public Pelicula Pelicula { get; set; }


        public ICommand cmdAgregarPeli { get; set; }
        public DetallesViewModel(Pelicula pelicula)
        {

            Pelicula = pelicula;

            cmdAgregarPeli = new Command<Pelicula>((item) => cmdGrabaMovieMetodo(item));

        }




        private void cmdGrabaMovieMetodo(Pelicula pelicula)
        {
            App.PeliculasDb.InsertOrUpdate(pelicula);
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
