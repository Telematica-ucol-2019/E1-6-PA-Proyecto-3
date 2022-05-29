using Peliculas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Peliculas.ViewModels
{
    public class ListaProductoraViewModel : BaseViewModel
    {
        public ObservableCollection<Productora> Productoras { get; set; }
        public Pelicula Pelicula { get; set; }

        public ListaProductoraViewModel(Pelicula pelicula)
        {
            Pelicula = pelicula;
            Productoras = pelicula.Productoras;
            cargarElementos();
        }

        private void cargarElementos()
        {
            throw new NotImplementedException();
        }
    }
}
