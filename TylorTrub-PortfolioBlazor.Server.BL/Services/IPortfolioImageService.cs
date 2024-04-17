using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.DTO.Models;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public interface IPortfolioImageService
    {
        Task<List<PortfolioImage>> FetchPortfolioImagesAsync();
    }
}
