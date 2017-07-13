using System;

namespace SpecPattern.Framework.Data.Entities
{
    public class Movie : Entity
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }

  
    }
}
