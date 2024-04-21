using TylorTrubPortfolioBlazor.DTO.Models;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public interface IGamesService
    {
        Task<List<Game>> FetchGamesAsync();
    }
}
