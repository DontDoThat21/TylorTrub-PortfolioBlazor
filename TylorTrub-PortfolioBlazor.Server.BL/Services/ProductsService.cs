using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class ProductsService : IProductsService
    {
        private readonly PortfolioDBContext dbContext;

        public ProductsService(PortfolioDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public async Task<List<Product>> FetchProductsAsync()
        {
            var products = await dbContext.Products.ToListAsync();

            return products;
        }
        
        public async Task<Product> FetchProductsAsync(int productId)
        {
            //Motorcycle motorcycle = (Motorcycle)await dbContext.FindAsync(motorcycleId);
            //return motorcycle;

            return await dbContext.Products.FindAsync(productId);
        }
    }
}
