using Peliculas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Peliculas.ViewModels
{
    public class DetallesActoresViewModel : BaseViewModel
    {
        public ObservableCollection<Actor> Actores { get; set; }
        public Pelicula Pelicula { get; set; }
        public DetallesActoresViewModel(Pelicula pelicula)
        {
            Pelicula = pelicula;
            //Actores = new ObservableCollection<Actor>(App.ActoresDb.GetAll());
            Actores = pelicula.Actores;
        }
        public DetallesActoresViewModel()
        {
            Actores = new ObservableCollection<Actor>(App.ActoresDb.GetAll());
        }
    }
}
