using Peliculas.Models;
using Peliculas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Peliculas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaActores : ContentPage
    {
        public ListaActores(Pelicula pelicula)
        {
            InitializeComponent();
            BindingContext = new ListaActoresViewModel(pelicula);
        }
        public ListaActores()
        {
            InitializeComponent();
            BindingContext = new ListaActoresViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}