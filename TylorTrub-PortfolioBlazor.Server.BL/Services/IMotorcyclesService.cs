using TylorTrubPortfolioBlazor.DTO.Models;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public interface IMotorcyclesService
    {
        Task<List<Motorcycle>> FetchMotorcyclesAsync();
        Task<Motorcycle> FetchMotorcycleAsync(int motorcycleId);
    }
}
