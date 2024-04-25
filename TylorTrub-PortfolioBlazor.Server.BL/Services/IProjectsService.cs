using TylorTrubPortfolioBlazor.DTO.Models;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public interface IProjectsService : IService<Project>
    {
        Task<List<Project>> FetchProjectsAsync();
    }
}
