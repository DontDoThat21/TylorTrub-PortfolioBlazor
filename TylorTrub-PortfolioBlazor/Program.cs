using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using System.Threading.Tasks;
using TylorTrubPortfolioBlazor.Server.BL.Data;
using TylorTrubPortfolioBlazor.Server.BL.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Fluxor;
using System.Reflection;
using MudExtensions.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Fluxor.Blazor.Web.ReduxDevTools;
using TylorTrubPortfolio.Server.BL.Repository;
using System.Security.Claims;

namespace TylorTrubPortfolioBlazor
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
            builder.Services.AddAuthorizationBuilder();

            // Add DbContext
            builder.Services.AddDbContext<PortfolioDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<PortfolioDBContext>()
                .AddApiEndpoints();

            // Add Controllers with Views
            builder.Services.AddControllersWithViews();

            // Add other services
            builder.Services.AddScoped<IPortfolioImagesService, PortfolioImagesService>();
            builder.Services.AddScoped<IProjectsService, ProjectsService>();
            builder.Services.AddScoped<IMotorcycleVideosService, MotorcycleVideosService>();
            builder.Services.AddScoped<IMotorcyclesService, MotorcyclesService>();
            builder.Services.AddScoped<IProductsService, ProductsService>();
            builder.Services.AddScoped<IGamesService, GamesService>();
            builder.Services.AddScoped<ICompaniesService, CompaniesService>();
            builder.Services.AddScoped<ICategoriesService, CategoriesService>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<TylorTrubPortfolio.Client.BL.IEmailSender, TylorTrubPortfolio.Client.BL.EmailSender>();

            // Add Blazor and MudBlazor services
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddMudBlazorDialog()
                .AddMudServices()
                .AddHotKeys2();

            // Add Fluxor
            builder.Services.AddFluxor(options =>
            {
                options.ScanAssemblies(Assembly.GetExecutingAssembly());
                options.UseReduxDevTools();
            });

            // Add HttpContextAccessor
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddMudExtensions();

            // Configure forwarded headers
            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            var app = builder.Build();

            app.MapGet("/", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name}")
                .RequireAuthorization();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
