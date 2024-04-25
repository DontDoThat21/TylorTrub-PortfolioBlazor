using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolio.Server.BL.Repository;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class ProductsService : Service<Product>, IProductsService
    {
        private readonly PortfolioDBContext dbContext;

        public ProductsService(PortfolioDBContext dBContext) : base(dBContext)
        {
            this.dbContext = dBContext;
        }

        public async Task<List<Product>> FetchProductsAsync()
        {
            var products = await dbContext.Products.ToListAsync();

            return products;
        }
        
        public async Task<Product> FetchProductAsync(int productId)
        {
            //Motorcycle motorcycle = (Motorcycle)await dbContext.FindAsync(motorcycleId);
            //return motorcycle;

            return await dbContext.Products.FindAsync(productId);
        }
    }
}
