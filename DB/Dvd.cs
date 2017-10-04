using System.Collections.Generic;

namespace DB
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public bool Dvd { get; set; }

        public virtual List<Actor> Actors { get; set; }
    }
}
