using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Repositories
{
    public interface ILogoRepository
    {
        Task<Logo> CreateAsync(Logo logo);
        Task<Logo?> UpdateAsync(Guid id, Logo logo);
        Task<Logo?> DeleteAsync(Guid id);
    }
}
