using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peliculas.Models
{
    [Table("Productoras")]
    public class Productora
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Logo { get; set; }
    }
}
