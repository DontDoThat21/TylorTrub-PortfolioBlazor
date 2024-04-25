using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolio.Server.BL.Repository;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class CategoriesService : Service<Category>, ICategoriesService
    {
        private readonly PortfolioDBContext dbContext;

        public CategoriesService(PortfolioDBContext dBContext) : base(dBContext)
        {
            this.dbContext = dBContext;
        }

        public async Task<List<Category>> FetchCategoriesAsync()
        {
            var categories = await dbContext.Categories.ToListAsync();

            return categories;
        }
    }
}
