using Microsoft.EntityFrameworkCore;
using PanchaMukhiMarbles.API1.Data;
using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Repositories
{
    public class SQLSocialMediaRepository:ISocialMediaRepository
    {
        private readonly PanchaMukhiMarblesDbContext dbContext;

        public SQLSocialMediaRepository(PanchaMukhiMarblesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<SocialMedia> CreateAsync(SocialMedia socialMedia)
        {
            await dbContext.socialMedias.AddAsync(socialMedia); 
            await dbContext.SaveChangesAsync();
            return socialMedia;
        }

        public async Task<SocialMedia?> DeleteAsync(Guid id)
        {
           var existingSocialMedia=await dbContext.socialMedias.FirstOrDefaultAsync(s => s.Id == id);
            if (existingSocialMedia == null)
            {
                return null;
            }
            dbContext.socialMedias.Remove(existingSocialMedia);
            await dbContext.SaveChangesAsync();
            return existingSocialMedia;
        }

        public async Task<List<SocialMedia?>> GetAllAsync()
        {
            return await dbContext.socialMedias.ToListAsync();
        }

        public async Task<SocialMedia?> GetByIdAsync(Guid id)
        {
           return await dbContext.socialMedias.FirstOrDefaultAsync(x=> x.Id == id); 
        }

        public async Task<SocialMedia?> UpdateAsync(Guid id, SocialMedia socialMedia)
        {
            var existingSocialMedia=await dbContext.socialMedias.FirstOrDefaultAsync(x=>x.Id == id);
            if (existingSocialMedia == null)
            {
                return null;
            }
            existingSocialMedia.Facebook=socialMedia.Facebook;
            existingSocialMedia.Twitter = socialMedia.Twitter;
            existingSocialMedia.Tiktok=socialMedia.Tiktok;
            existingSocialMedia.Instagram=socialMedia.Instagram;
            await dbContext.SaveChangesAsync();
            return socialMedia;
        }
    }
}
