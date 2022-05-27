using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peliculas.Models
{
    [Table("ActoresPeliculas")]
    public class ActorPelicula
    {
        
        public int Id { get; set; }

        [ForeignKey(typeof(Pelicula))]
        public int FKPeliculaId { get; set; }

        [ForeignKey(typeof(Actor))]
        public int FKActorId { get; set; }

    }
}
