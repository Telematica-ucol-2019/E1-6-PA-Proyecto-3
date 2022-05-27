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
        public void InsertOrUpdate(Productora productora)
        {
            if (productora.Id == 0)
            {
                connection.Insert(productora);
            }
            else
            {
                connection.Update(productora);
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
            Productora productora = GetById(Id);
            connection.Delete(productora);
        }
    }
}
