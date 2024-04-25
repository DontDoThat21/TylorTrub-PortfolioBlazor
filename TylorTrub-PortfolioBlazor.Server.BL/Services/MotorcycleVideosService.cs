using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolio.Server.BL.Repository;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class MotorcycleVideosService : Service<MotorcycleVideo>, IMotorcycleVideosService
    {
        private readonly PortfolioDBContext dbContext;

        public MotorcycleVideosService(PortfolioDBContext dBContext) : base(dBContext)
        {
            this.dbContext = dBContext;
        }

        public async Task<List<MotorcycleVideo>> FetchMotorcycleVideosAsync()
        {
            var motorcycleVideos = await dbContext.MotorcycleVideos.ToListAsync();

            return motorcycleVideos;
        }
    }
}
