using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolio.Server.BL.Repository;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class GamesService : Service<Game>, IGamesService
    {
        private readonly PortfolioDBContext dbContext;

        public GamesService(PortfolioDBContext dBContext) : base(dBContext)
        {
            this.dbContext = dBContext;
        }

        public async Task<List<Game>> FetchGamesAsync()
        {
            var games = await dbContext.Games.ToListAsync();

            return games;
        }
    }
}
