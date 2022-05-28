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
    public class ActorRepositorio
    {
        SQLiteConnection connection;
        public ActorRepositorio()
        {
            connection = new SQLiteConnection(Constants.Constantes.DatabasePath, Constants.Constantes.Flags);
            connection.CreateTable<Actor>();
        }
        public void Init()
        {
            //AgregarDesdeInicio("Unkwnown", "The secret user");
            connection.CreateTable<Actor>();
        }
        private void AgregarDesdeInicio(string nombre, string alias)
        {
            Actor actor = GetByName(nombre);
            if (actor == null)
            {
                InsertOrUpdate(new Actor() { Nombre = nombre, Alias = alias });
            }
        }
        public void InsertOrUpdate(Actor actor)
        {
            if (actor.Id == 0)
            {
                Debug.WriteLine($"Id antes de registrar {actor.Id}");
                connection.Insert(actor);
                Debug.WriteLine($"Id despues de registrar {actor.Id}");
            }
            else
            {
                Debug.WriteLine($"Id antes de actualizar {actor.Id}");
                connection.Update(actor);
                Debug.WriteLine($"Id despues de actualizar {actor.Id}");
            }
        }
        public Actor GetById(int Id)
        {
            return connection.Table<Actor>().FirstOrDefault(item => item.Id == Id);
        }
        public Actor GetByName(string nombre)
        {
            return connection.Table<Actor>().FirstOrDefault(item => item.Nombre == nombre);
        }
        public List<Actor> GetAll()
        {
            return connection.GetAllWithChildren<Actor>().ToList();
        }
        public void DeleteItem(int Id)
        {
            Actor actor = GetById(Id);
            connection.Delete(actor);
        }
    }
}
