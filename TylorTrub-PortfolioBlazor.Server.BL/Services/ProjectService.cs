using Microsoft.EntityFrameworkCore;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly PortfolioDBContext dbContext;

        public ProjectService(PortfolioDBContext dBContext)
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
