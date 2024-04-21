using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;
using TylorTrubPortfolioBlazor.DTO.Models;
using TylorTrubPortfolioBlazor.DTO.ViewModels;
using TylorTrubPortfolioBlazor.Server.BL.Data;

namespace TylorTrubPortfolioBlazor.Server.BL.Services
{
    public class CartsService : ICartsService
    {
        private readonly PortfolioDBContext dbContext;

        public CartsService(PortfolioDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public ShoppingCartBundle bundles { get; set; }


        public async Task<List<ShoppingCartBundle>> FetchCartsAsync()
        {
            return null;
            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            bundles = new()
            {
                //ShoppingCartList = dbContext.ShoppingCarts.GetAll(u => u.ApplicationUserId == userId,
                //includeProperties: "Product"),
                //OrderHeader = new()
            };

            //IEnumerable<ProductImage> productImages = _unitOfWork.ProductImage.GetAll();

            foreach (var cart in bundles.ShoppingCartList)
            {
                //cart.Product.ProductImages = productImages.Where(u => u.ProductId == cart.Product.Id).ToList();
                //cart.Price = GetPriceBasedOnQuantity(cart);
                bundles.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }

            //return View(bundles);
        }

        //IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

    }
}
