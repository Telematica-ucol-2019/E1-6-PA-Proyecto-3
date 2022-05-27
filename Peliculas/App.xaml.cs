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
        private static ProductoraRepositorio _ProductorasDb;
        public static ProductoraRepositorio ProductorasDb
        {
            get
            {
                if (_ProductorasDb == null)
                {
                    _ProductorasDb = new ProductoraRepositorio();
                }
                return _ProductorasDb;

            }
        }
        public App()
        {
            InitializeComponent();
            PeliculasDb.Init();
            ProductorasDb.Init();
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
