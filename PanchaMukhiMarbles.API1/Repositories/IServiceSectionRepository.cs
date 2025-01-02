using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Repositories
{
    public interface IServiceSectionRepository
    {
        Task<ServiceSection> CreateAsync(ServiceSection serviceSectionDomainModel);
        Task<ServiceSection?> GetByIdAsync(Guid id);
        Task<List<ServiceSection>> GetAllAsync();
        Task<ServiceSection?> UpdateAsync(Guid id,ServiceSection serviceSection);
        Task<ServiceSection?> DeleteAsync(Guid id);
    }
}
