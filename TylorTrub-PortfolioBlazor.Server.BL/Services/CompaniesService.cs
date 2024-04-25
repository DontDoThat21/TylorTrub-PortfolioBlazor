using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolio.Server.BL.Repository;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class CompaniesService : Service<Company>, ICompaniesService
    {
        private readonly PortfolioDBContext dbContext;

        public CompaniesService(PortfolioDBContext dBContext) : base(dBContext)
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
