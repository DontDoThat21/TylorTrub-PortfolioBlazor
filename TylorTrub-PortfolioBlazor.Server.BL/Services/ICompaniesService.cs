using TylorTrubPortfolioBlazor.DTO.Models;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public interface ICompaniesService
    {
        Task<List<Company>> FetchCompaniesAsync();
    }
}
