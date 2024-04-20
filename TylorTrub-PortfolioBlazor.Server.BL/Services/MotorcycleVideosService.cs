using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class MotorcycleVideosService : IMotorcycleVideosService
    {
        private readonly PortfolioDBContext dbContext;

        public MotorcycleVideosService(PortfolioDBContext dBContext)
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
