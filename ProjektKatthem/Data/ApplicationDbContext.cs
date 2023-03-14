using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjektKatthem.Models;

namespace ProjektKatthem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cats> Cats { get; set; }
        public DbSet<Adopt> Adopt { get; set; }

       
    }

    
}
