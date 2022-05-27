using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Peliculas.Models
{
    [Table("Actores")]
    public class Actor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Alias { get; set; }

        [ForeignKey(typeof(Pelicula))]
        public int FKPeliculaId { get; set; }
        [ManyToMany(typeof(ActorPelicula), CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Pelicula> Peliculas { get; set; }
    }
}
