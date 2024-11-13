using Microsoft.EntityFrameworkCore;

namespace B05ASPC22_w01.Models
{

    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Diseases> Diseases { get; set; }
    }

    
}

