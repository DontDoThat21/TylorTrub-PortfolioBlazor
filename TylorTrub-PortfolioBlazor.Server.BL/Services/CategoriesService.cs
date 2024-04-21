using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly PortfolioDBContext dbContext;

        public CategoriesService(PortfolioDBContext dBContext)
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
