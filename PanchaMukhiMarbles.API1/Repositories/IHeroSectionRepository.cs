using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Repositories
{
    public interface IHeroSectionRepository
    {
        Task<List<HeroSection>> GetAllAsync();
        Task<HeroSection?> GetByIdAsync(Guid id);
        Task<HeroSection> CreateAsync(HeroSection heroSection);
        Task<HeroSection?> UpdateAsync(Guid id,HeroSection heroSection);
        Task<HeroSection?> DeleteAsync(Guid id);
    }
}
