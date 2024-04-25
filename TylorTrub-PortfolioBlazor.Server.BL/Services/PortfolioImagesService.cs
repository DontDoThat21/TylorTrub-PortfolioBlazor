using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolio.Server.BL.Repository;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class PortfolioImagesService : Service<PortfolioImage>, IPortfolioImagesService
    {
        private readonly PortfolioDBContext dbContext;

        public PortfolioImagesService(PortfolioDBContext dBContext) : base(dBContext)
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
