using Microsoft.EntityFrameworkCore;
using PanchaMukhiMarbles.API1.Data;
using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Repositories
{
    public class SQLExploreSectionRepository : IExploreSectionRepository
    {
        private readonly PanchaMukhiMarblesDbContext dbContext;

        public SQLExploreSectionRepository(PanchaMukhiMarblesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ExploreSection> CreateAsync(ExploreSection exploreSection)
        {
            await dbContext.exploreSections.AddAsync(exploreSection);
            await dbContext.SaveChangesAsync();
            return exploreSection;
        }

        public async Task<ExploreSection?> DeleteAsync(Guid id)
        {
            var existingexploresection = await dbContext.exploreSections.FirstOrDefaultAsync(x => x.Id == id);
            if (existingexploresection==null)
            {
                return null;
            }
            dbContext.exploreSections.Remove(existingexploresection);
            await dbContext.SaveChangesAsync();
            return existingexploresection;
        }

        public async Task<List<ExploreSection>> GetAllAsync()
        {
            return await dbContext.exploreSections.ToListAsync();
        }

        public async Task<ExploreSection?> GetByIdAsync(Guid id)
        {
            return await dbContext.exploreSections.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ExploreSection?> UpdateAsync(Guid id, ExploreSection exploreSection)
        {
            var existingexploresection = await dbContext.exploreSections.FirstOrDefaultAsync(x => x.Id == id);
            if(existingexploresection==null)
            {
                return null;
            }
            existingexploresection.Title = exploreSection.Title;
            existingexploresection.Paragraph = exploreSection.Paragraph;
            existingexploresection.ImageUrl = exploreSection.ImageUrl;
            await dbContext.SaveChangesAsync();
            return  existingexploresection;
        }
    }
}
