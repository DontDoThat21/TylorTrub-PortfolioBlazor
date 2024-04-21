using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class GamesService : IGamesService
    {
        private readonly PortfolioDBContext dbContext;

        public GamesService(PortfolioDBContext dBContext)
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
