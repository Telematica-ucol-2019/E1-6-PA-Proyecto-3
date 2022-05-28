using Peliculas.Constants;
using Peliculas.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Peliculas.Repositories
{
    public class PeliculaRepositorio
    {
        SQLiteConnection connection;
        public PeliculaRepositorio()
        {
            connection = new SQLiteConnection(Constants.Constantes.DatabasePath, Constants.Constantes.Flags);
            connection.CreateTable<Pelicula>();
        }
        public void Init()
        {
            connection.CreateTable<Pelicula>();
        }
        public void InsertOrUpdate(Pelicula pelicula)
        {
            if (pelicula.Id == 0)
            {
                Debug.WriteLine($"Id antes de registrar {pelicula.Id}");
                connection.InsertWithChildren(pelicula);
                Debug.WriteLine($"Id despues de registrar {pelicula.Id}");
            }
            else
            {
                Debug.WriteLine($"Id antes de actualizar {pelicula.Id}");
                connection.Update(pelicula);
                App.ProductorasDb.InsertOrUpdate(pelicula.Productora);
                Debug.WriteLine($"Id despues de actualizar {pelicula.Id}");
            }
        }
        public Pelicula GetById(int Id)
        {
            return connection.Table<Pelicula>().FirstOrDefault(item => item.Id == Id);
        }
        public List<Pelicula> GetAll()
        {
            return connection.GetAllWithChildren<Pelicula>().ToList();
        }
        public void DeleteItem(int Id)
        {
            Pelicula pelicula = GetById(Id);
            connection.Delete(pelicula);
        }
    }
}
