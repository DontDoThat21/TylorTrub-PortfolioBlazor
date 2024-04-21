using TylorTrubPortfolioBlazor.DTO.Models;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public interface IProductsService
    {
        Task<List<Product>> FetchProductsAsync();
        Task<Product> FetchProductsAsync(int productId);
    }
}
