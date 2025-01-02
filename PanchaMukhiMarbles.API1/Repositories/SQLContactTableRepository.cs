using Microsoft.EntityFrameworkCore;
using PanchaMukhiMarbles.API1.Data;
using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Repositories
{
    public class SQLContactTableRepository:IContactTableRepository
    {
        private readonly PanchaMukhiMarblesDbContext dbContext;

        public SQLContactTableRepository(PanchaMukhiMarblesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ContactTable> CreateAsync(ContactTable contactTable)
        {
            await dbContext.contactTables.AddAsync(contactTable);
            await dbContext.SaveChangesAsync();
            return contactTable;
        }

        public async Task<ContactTable> DeleteAsync(Guid id)
        {
            var existingContactTable=await dbContext.contactTables.FirstOrDefaultAsync(x=>x.Id == id);
            if (existingContactTable == null)
            {
                return null;
            }
            dbContext.contactTables.Remove(existingContactTable);
            await dbContext.SaveChangesAsync(); 
            return existingContactTable;
        }

        public async Task<List<ContactTable>> GetAllAsync()
        {
            return await dbContext.contactTables.ToListAsync();
        }

        public async Task<ContactTable> GetByIdAsync(Guid id)
        {
            return await dbContext.contactTables.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ContactTable> UpdateAsync(Guid id, ContactTable contactTable)
        {
            var existingContactTable = await dbContext.contactTables.FirstOrDefaultAsync(x => x.Id == id);
            if (existingContactTable == null)
            {
                return null;
            }
            existingContactTable.PhoneNumber = contactTable.PhoneNumber;
            existingContactTable.Whatsapp= contactTable.Whatsapp;
            existingContactTable.Gmail = contactTable.Gmail;
            existingContactTable.Address=contactTable.Address;
            await dbContext.SaveChangesAsync();
            return existingContactTable;
        }
    }
}
