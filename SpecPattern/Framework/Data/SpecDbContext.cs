using Microsoft.EntityFrameworkCore;
using SpecPattern.Framework.Data.Entities;

namespace SpecPattern.Framework.Data
{
    public class SpecDbContext : DbContext
    {
        public SpecDbContext(DbContextOptions<SpecDbContext> options)
             :base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }


    }
}
