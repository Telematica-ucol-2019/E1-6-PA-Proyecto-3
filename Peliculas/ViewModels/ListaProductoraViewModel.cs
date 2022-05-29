using Peliculas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Peliculas.ViewModels
{
    public class ListaProductoraViewModel : BaseViewModel
    {
        public Pelicula Pelicula { get; set; }
        public Productora Productora { get; set; }

        public ListaProductoraViewModel(Pelicula pelicula)
        {
            Pelicula = pelicula;
            Productora = pelicula.Productora;
        }
    }
}
