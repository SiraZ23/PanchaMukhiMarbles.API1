using Microsoft.EntityFrameworkCore;
using PanchaMukhiMarbles.API1.Data;
using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Repositories
{
    public class SQLAboutSectionRepository : IAboutSectionRepository
    {
        private readonly PanchaMukhiMarblesDbContext dbContext;

        public SQLAboutSectionRepository(PanchaMukhiMarblesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<AboutSection> CreateAsync(AboutSection aboutSection)
        {
           await dbContext.aboutSections.AddAsync(aboutSection);
           await dbContext.SaveChangesAsync();
           return aboutSection;
        }

        public async Task<AboutSection?> DeleteAsync(Guid id)
        {
           var existingaboutsection=await dbContext.aboutSections.FirstOrDefaultAsync(x => x.Id == id); 
            if (existingaboutsection == null)
            {
                return null;
            }
            dbContext.aboutSections.Remove(existingaboutsection);
            await dbContext.SaveChangesAsync();
            return existingaboutsection;
        }

        public async Task<List<AboutSection>> GetAllAsync()
        {
            return await dbContext.aboutSections.ToListAsync();
        }

        public async Task<AboutSection?> GetByIdAsync(Guid id)
        {
            return await dbContext.aboutSections.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<AboutSection?> UpdateAsync(Guid id, AboutSection aboutSection)
        {
            var existingaboutsection = await dbContext.aboutSections.FirstOrDefaultAsync(x => x.Id == id);
            if (existingaboutsection ==null)
            {
                return null;
            }
            existingaboutsection.Title = aboutSection.Title;
            existingaboutsection.Paragraph=aboutSection.Paragraph;
            existingaboutsection.ImageUrl=aboutSection.ImageUrl;
            await dbContext.SaveChangesAsync();
            return existingaboutsection;
        }

    }
}
