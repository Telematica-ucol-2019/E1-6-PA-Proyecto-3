using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peliculas.Models
{
    [Table("Actores")]
    public class Actor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Alias { get; set; }

        [ForeignKey(typeof(Pelicula))]

        public int FKPelicula { get; set; }
    }
}
