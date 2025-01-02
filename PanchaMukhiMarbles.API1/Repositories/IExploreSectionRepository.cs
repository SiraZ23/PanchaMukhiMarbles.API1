using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Repositories
{
    public interface IExploreSectionRepository
    {
        Task<ExploreSection> CreateAsync(ExploreSection exploreSection);
        Task<List<ExploreSection>> GetAllAsync();
        Task<ExploreSection?> GetByIdAsync(Guid id);
        Task<ExploreSection?> UpdateAsync(Guid id, ExploreSection exploreSection);
        Task<ExploreSection?> DeleteAsync(Guid id);
    }
}
