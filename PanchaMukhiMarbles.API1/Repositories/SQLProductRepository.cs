using Microsoft.EntityFrameworkCore;
using PanchaMukhiMarbles.API1.Data;
using PanchaMukhiMarbles.API1.Models.Domain;

namespace PanchaMukhiMarbles.API1.Repositories
{    
    public class SQLProductRepository : IProductRepository
    {
        private readonly PanchaMukhiMarblesDbContext dbContext;

        public SQLProductRepository(PanchaMukhiMarblesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> CreateAsync(Product product)
        {
           await dbContext.products.AddAsync(product);
            await dbContext.SaveChangesAsync(); 
            return product;
        }

        public async Task<Product?> DeleteAsync(Guid id)
        {
            var existionProduct=await dbContext.products.FirstOrDefaultAsync(x => x.Id == id);
            if (existionProduct == null)
            {
                return null;
            }
            dbContext.products.Remove(existionProduct);
            await dbContext.SaveChangesAsync();
            return existionProduct;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await dbContext.products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
           return await dbContext.products.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<Product?> UpdateAsync(Guid id, Product product)
        {
            var existingProduct = await dbContext.products.FirstOrDefaultAsync(x => x.Id == id);
            if(existingProduct == null)
            {
                return null;
            }
            existingProduct.ProductName= product.ProductName;
            existingProduct.Thickness= product.Thickness;
            existingProduct.ImageUrl=product.ImageUrl;
            existingProduct.Price= product.Price;
            existingProduct.Stock= product.Stock;
            existingProduct.Category= product.Category;
            await dbContext.SaveChangesAsync();
            return existingProduct;
        }
    }
}
