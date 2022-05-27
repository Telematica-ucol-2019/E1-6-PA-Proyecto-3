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
    public class ActorPeliculaRepositorio
    {
        SQLiteConnection connection;
        public ActorPeliculaRepositorio()
        {
            connection = new SQLiteConnection(Constants.Constantes.DatabasePath, Constants.Constantes.Flags);
            connection.CreateTable<ActorPelicula>();
        }

        public void Init()
        {
            connection.CreateTable<ActorPelicula>();
        }
        public void InsertOrUpdate(ActorPelicula actorPelicula)
        {
            if (actorPelicula.Id == 0)
            {
                Debug.WriteLine($"Id antes de registrar {actorPelicula.Id}");
                connection.InsertWithChildren(actorPelicula);
                Debug.WriteLine($"Id despues de registrar {actorPelicula.Id}");
            }
            else
            {
                Debug.WriteLine($"Id antes de actualizar {actorPelicula.Id}");
                connection.InsertOrReplaceWithChildren(actorPelicula);
                Debug.WriteLine($"Id despues de actualizar {actorPelicula.Id}");
            }
        }
        public ActorPelicula GetById(int Id)
        {
            return connection.Table<ActorPelicula>().FirstOrDefault(item => item.Id == Id);
        }
        public List<ActorPelicula> GetAll()
        {
            return connection.GetAllWithChildren<ActorPelicula>().ToList();
        }
        public void DeleteItem(int Id)
        {
            ActorPelicula actorPelicula = GetById(Id);
            connection.Delete(actorPelicula);
        }
    }
}
