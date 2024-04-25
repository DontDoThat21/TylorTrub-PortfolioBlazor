using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolio.Server.BL.Repository;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class ProjectsService : Service<Project>, IProjectsService
    {
        private readonly PortfolioDBContext dbContext;

        public ProjectsService(PortfolioDBContext dBContext) : base(dBContext)
        {
            this.dbContext = dBContext;
        }

        public async Task<List<Project>> FetchProjectsAsync()
        {
            var projects = await dbContext.Projects.ToListAsync();

            return projects;
        }
    }
}
