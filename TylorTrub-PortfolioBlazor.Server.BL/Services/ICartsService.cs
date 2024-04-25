using TylorTrubPortfolioBlazor.DTO.Models;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public interface ICartsService : IService<ShoppingCartBundle>
    {
        Task<List<ShoppingCartBundle>> FetchCartsAsync();
    }
}
