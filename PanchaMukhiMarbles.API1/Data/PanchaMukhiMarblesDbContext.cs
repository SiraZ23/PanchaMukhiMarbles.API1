using Microsoft.EntityFrameworkCore;
using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Data
{
    public class PanchaMukhiMarblesDbContext:DbContext
    {
        public PanchaMukhiMarblesDbContext(DbContextOptions dbContextOptions):base (dbContextOptions)
        {
            
        }
        public DbSet<SocialMedia> socialMedias { get; set; }
        public DbSet<ContactTable> contactTables { get; set; }
        public DbSet<ExploreSection> exploreSections { get; set; }
        public DbSet<HeroSection> heroSections { get; set; }
        public DbSet<Logo> logos { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ServiceSection> serviceSections { get; set; }
        public DbSet<AboutSection> aboutSections { get; set; }
    }
}
