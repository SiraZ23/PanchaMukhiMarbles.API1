using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Repositories
{
    public interface IContactTableRepository
    {
        Task<ContactTable> CreateAsync(ContactTable contactTable);
        Task<List<ContactTable>> GetAllAsync();
        Task<ContactTable> GetByIdAsync(Guid id);
        Task<ContactTable> UpdateAsync(Guid id,ContactTable contactTable);
        Task<ContactTable> DeleteAsync(Guid id);
    }
}
