using Microsoft.EntityFrameworkCore;
using PanchaMukhiMarbles.API1.Data;
using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Repositories
{
    public class SQLHeroSectionRepository:IHeroSectionRepository
    {
        private readonly PanchaMukhiMarblesDbContext dbContext;

        public SQLHeroSectionRepository(PanchaMukhiMarblesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<HeroSection> CreateAsync(HeroSection heroSection)
        {
            await dbContext.heroSections.AddAsync(heroSection);
            await dbContext.SaveChangesAsync();
            return heroSection;
        }

        public async Task<HeroSection?> DeleteAsync(Guid id)
        {
            var existingHeroSection = await dbContext.heroSections.FirstOrDefaultAsync(x => x.Id == id);
            if (existingHeroSection == null)
            {
                return null;
            }
            dbContext.heroSections.Remove(existingHeroSection);
            await dbContext.SaveChangesAsync();
            return existingHeroSection;
        }

        public async Task<List<HeroSection>> GetAllAsync()
        {
            return await dbContext.heroSections.ToListAsync();
        }

        public async Task<HeroSection?> GetByIdAsync(Guid id)
        {
            return await dbContext.heroSections.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<HeroSection?> UpdateAsync(Guid id, HeroSection heroSection)
        {
           var existingHeroSection=await dbContext.heroSections.FirstOrDefaultAsync(x=>x.Id==id);
            if (existingHeroSection==null)
            {
                return null;
            }
            existingHeroSection.HeroSectionTitle=heroSection.HeroSectionTitle;
            existingHeroSection.ImageUrl=heroSection.ImageUrl;
            await dbContext.SaveChangesAsync();
            return existingHeroSection;
        }
    }
}
