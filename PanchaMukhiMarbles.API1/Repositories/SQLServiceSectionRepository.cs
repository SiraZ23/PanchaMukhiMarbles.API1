using Microsoft.EntityFrameworkCore;
using PanchaMukhiMarbles.API1.Data;
using PanchaMukhiMarbles.API1.Models.Domain;
using PanchaMukhiMarbles.API1.Models.DTO;

namespace PanchaMukhiMarbles.API1.Repositories
{
    public class SQLServiceSectionRepository:IServiceSectionRepository
    {
        private readonly PanchaMukhiMarblesDbContext dbContext;

        public SQLServiceSectionRepository(PanchaMukhiMarblesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ServiceSection> CreateAsync(ServiceSection serviceSectionDomainModel)
        {
           await dbContext.serviceSections.AddAsync(serviceSectionDomainModel);
            await dbContext.SaveChangesAsync();
            return serviceSectionDomainModel;
        }

        public async Task<ServiceSection?> DeleteAsync(Guid id)
        {
            var existingServiceSection=await dbContext.serviceSections.FirstOrDefaultAsync(x=>x.Id==id);
            if (existingServiceSection==null)
            {
                return null;
            }
            dbContext.serviceSections.Remove(existingServiceSection);
            await dbContext.SaveChangesAsync();
            return existingServiceSection;
        }

        public async Task<List<ServiceSection>> GetAllAsync()
        {
            return await dbContext.serviceSections.ToListAsync();
        }

        public async Task<ServiceSection?> GetByIdAsync(Guid id)
        {
           return await dbContext.serviceSections.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<ServiceSection?> UpdateAsync(Guid id, ServiceSection serviceSection)
        {
           var existingServiceSection=await dbContext.serviceSections.FirstOrDefaultAsync(x=>x.Id==id);
            if (existingServiceSection == null)
            {
                return null;
            }
            existingServiceSection.PageTitle = serviceSection.PageTitle;
            existingServiceSection.ServiceTitle= serviceSection.ServiceTitle;
            existingServiceSection.ServiceDescription= serviceSection.ServiceDescription;
            await dbContext.SaveChangesAsync();
            return serviceSection;
        }
    }
}
