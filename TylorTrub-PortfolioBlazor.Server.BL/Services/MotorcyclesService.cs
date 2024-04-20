using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class MotorcyclesService : IMotorcyclesService
    {
        private readonly PortfolioDBContext dbContext;

        public MotorcyclesService(PortfolioDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public async Task<List<Motorcycle>> FetchMotorcyclesAsync()
        {
            var motorcycles = await dbContext.Motorcycles.ToListAsync();

            return motorcycles;
        }
        
        public async Task<Motorcycle> FetchMotorcycleAsync(int motorcycleId)
        {
            //Motorcycle motorcycle = (Motorcycle)await dbContext.FindAsync(motorcycleId);
            //return motorcycle;

            return await dbContext.Motorcycles.FindAsync(motorcycleId);
        }
    }
}
