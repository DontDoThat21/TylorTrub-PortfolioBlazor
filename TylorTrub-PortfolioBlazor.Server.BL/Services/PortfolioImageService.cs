using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class PortfolioImageService : IPortfolioImageService
    {
        private readonly PortfolioDBContext dbContext;

        public PortfolioImageService(PortfolioDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public async Task<List<PortfolioImage>> FetchPortfolioImagesAsync()
        {
            var pfImages = await dbContext.PortfolioImages.ToListAsync();

            return pfImages;
        }
    }
}
