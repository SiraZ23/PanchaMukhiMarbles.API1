using Microsoft.EntityFrameworkCore;
using PanchaMukhiMarbles.API1.Data;
using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Repositories
{
    public class SQLLogorepository : ILogoRepository
    {
        private readonly PanchaMukhiMarblesDbContext dbContext;

        public SQLLogorepository(PanchaMukhiMarblesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Logo> CreateAsync(Logo logo)
        {
            await dbContext.logos.AddAsync(logo);
            await dbContext.SaveChangesAsync();
            return logo;
        }

        public async Task<Logo?> DeleteAsync(Guid id)
        {
            var existingLogo = await dbContext.logos.FirstOrDefaultAsync(x => x.Id == id);
            if (existingLogo == null)
            {
                return null;
            }
            dbContext.logos.Remove(existingLogo);
            await dbContext.SaveChangesAsync();
            return existingLogo;
        }

        public async Task<Logo?> UpdateAsync(Guid id, Logo logo)
        {
            var existingLogo = await dbContext.logos.FirstOrDefaultAsync(x => x.Id == id);
            if (existingLogo == null)
            {
                return null;
            }
            existingLogo.LogoName= logo.LogoName;
            existingLogo.ImageUrl=logo.ImageUrl;
            await dbContext.SaveChangesAsync();
            return existingLogo;
        }
    }
}
