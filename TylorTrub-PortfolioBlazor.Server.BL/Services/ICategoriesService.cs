using TylorTrubPortfolioBlazor.DTO.Models;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public interface ICategoriesService
    {
        Task<List<Category>> FetchCategoriesAsync();
    }
}
