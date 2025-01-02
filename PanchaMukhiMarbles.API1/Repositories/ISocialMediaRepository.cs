using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Repositories
{
    public interface ISocialMediaRepository
    {
        Task<SocialMedia> CreateAsync(SocialMedia socialMedia);
        Task<SocialMedia?> UpdateAsync(Guid id, SocialMedia socialMedia);
        Task <SocialMedia?>DeleteAsync(Guid id);
        Task<SocialMedia?> GetByIdAsync(Guid id);
        Task<List<SocialMedia?>>GetAllAsync();
    }
}
