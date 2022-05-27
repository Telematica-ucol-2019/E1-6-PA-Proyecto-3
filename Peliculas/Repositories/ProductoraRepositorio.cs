using Peliculas.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peliculas.Repositories
{
     public class ProductoraRepositorio
    {
        SQLiteConnection connection;

        public ProductoraRepositorio()
        {
            connection = new SQLiteConnection(Constants.Constantes.DatabasePath, Constants.Constantes.Flags);
            connection.CreateTable<Productora>();
        }


        public void Init()
        {
            connection.CreateTable<Productora>();
        }
        public void InsertOrUpdate(Productora acta)
        {
            if (acta.Id == 0)
            {

                connection.Insert(acta);

            }
            else
            {

                connection.Update(acta);

            }
        }

        public Productora GetById(int Id)
        {
            return connection.Table<Productora>().FirstOrDefault(item => item.Id == Id);

        }


        public List<Productora> GetAll()
        {

            return connection.Table<Productora>().ToList();
        }


        public void DeleteItem(int Id)
        {
            Productora acta = GetById(Id);
            connection.Delete(acta);
        }
    }
}
