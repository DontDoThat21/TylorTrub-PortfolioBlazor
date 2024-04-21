using TylorTrubPortfolioBlazor.DTO.Models;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public interface ICartsService
    {
        Task<List<ShoppingCartBundle>> FetchCartsAsync();
    }
}
