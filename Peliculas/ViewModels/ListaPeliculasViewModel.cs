using Peliculas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Peliculas.ViewModels
{
    public class ListaPeliculasViewModel : BaseViewModel
    {
        public ObservableCollection<Pelicula> Peliculas { get; set; }
        public Actor Actor { get; set; }
        public ListaPeliculasViewModel(Actor actor)
        {
            Actor = actor;
            //Actores = new ObservableCollection<Actor>(App.ActoresDb.GetAll());
            Peliculas = actor.Peliculas;
        }
    }
}