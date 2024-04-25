using TylorTrubPortfolioBlazor.DTO.Models;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public interface ICategoriesService : IService<Category>
    {
        Task<List<Category>> FetchCategoriesAsync();
    }
}
