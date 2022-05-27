using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Peliculas.Models
{
    [Table("Peliculas")]
    public class Pelicula
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Portada { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }

        [ForeignKey(typeof(Productora))]
        public int FKProductora { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Productora Productora { get; set; }

        [ForeignKey(typeof(Actor))]
        public int FKActorId { get; set; }
        [ManyToMany(typeof(ActorPelicula), CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Actor> Actores { get; set; }
    }
}
