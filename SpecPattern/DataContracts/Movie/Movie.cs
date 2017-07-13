using System;

namespace SpecPattern.DataContracts.Movie
{
    public class Movie
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual string Genre { get; set; }
        public virtual double Rating { get; set; }
  
    }
}
