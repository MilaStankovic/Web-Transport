using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class Context : DbContext
    {
        public DbSet<Kompanija> Kompanija { get; set; }
        public DbSet<PrevoznoSredstvo> Vozila { get; set; }
        public DbSet<Isporuka> Isporuke { get; set; }


        public Context(DbContextOptions options) : base(options)
        {

        }
    }
}