using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Repositories
{
    public interface IAboutSectionRepository
    {
        Task<AboutSection>CreateAsync(AboutSection aboutSection);
        Task<List<AboutSection>> GetAllAsync();
        Task<AboutSection?> GetByIdAsync(Guid id);
        Task<AboutSection?> UpdateAsync(Guid id, AboutSection aboutSection);
        Task<AboutSection?> DeleteAsync(Guid id);
    }
}
