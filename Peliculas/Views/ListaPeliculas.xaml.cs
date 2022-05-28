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
    public partial class ListaPeliculas : ContentPage
    {

        public ListaPeliculas(Actor actor)
        {
            InitializeComponent();
            BindingContext = new ListaPeliculasViewModel(actor);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}