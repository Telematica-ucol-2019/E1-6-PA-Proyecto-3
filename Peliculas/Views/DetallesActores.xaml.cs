﻿using Peliculas.Models;
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
    public partial class DetallesActores : ContentPage
    {
        public DetallesActores(Pelicula pelicula)
        {
            InitializeComponent();
            BindingContext = new DetallesActoresViewModel(pelicula);
        }
        public DetallesActores()
        {
            InitializeComponent();
            BindingContext = new DetallesActoresViewModel();
        }
    }
}