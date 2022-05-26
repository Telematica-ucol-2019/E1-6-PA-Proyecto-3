using Peliculas.Repositories;
using Peliculas.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Peliculas
{
    public partial class App : Application
    {
        private static PeliculaRepositorio _PeliculasDb;
        public static PeliculaRepositorio PeliculasDb
        {
            get
            {
                if (_PeliculasDb == null)
                {
                    _PeliculasDb = new PeliculaRepositorio();
                }
                return _PeliculasDb;

            }
        }
        private static ProductoraRepositorio _ProductoraDb;
        public static ProductoraRepositorio ProductoraDb
        {
            get
            {
                if (_ProductoraDb == null)
                {
                    _ProductoraDb = new ProductoraRepositorio();
                }
                return _ProductoraDb;

            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new PaginaPrincipal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
