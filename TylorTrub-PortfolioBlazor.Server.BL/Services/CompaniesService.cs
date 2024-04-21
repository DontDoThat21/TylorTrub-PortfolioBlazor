using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly PortfolioDBContext dbContext;

        public CompaniesService(PortfolioDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public async Task<List<Company>> FetchCompaniesAsync()
        {
            var companies = await dbContext.Companies.ToListAsync();

            return companies;
        }
    }
}
