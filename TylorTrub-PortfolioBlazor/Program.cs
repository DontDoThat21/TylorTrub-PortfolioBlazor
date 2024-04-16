using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor;
using MudBlazor.Services;
using System.Net.Http.Headers;
using System;
using System.Threading.Tasks;
using TylorTrubPortfolioBlazor.Server.BL.Data;
using TylorTrubPortfolioBlazor.Server.BL.Services;
using TylorTrubPortfolioBlazor.UI.Services.Layout;
using TylorTrubPortfolioBlazor.UI.Services.UserPreferences;
using TylorTrubPortfolioBlazor.UI.Services.Layout.Notifications;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using TylorTrubPortfolioBlazor.UI.Services.Layout.Navigation;
using Fluxor;
using System.Reflection;
using Polly;
using TylorTrubPortfolioBlazor.UI.Services;
using TylorTrubPortfolioBlazor.UI.Services.Layout.JsInterop;
using MudExtensions.Services;

namespace TylorTrubPortfolioBlazor
{
    public class Program()
    {
        public static IConfiguration Configuration { get; set; }

        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddDbContext<PortfolioDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();
            builder.Services.AddCascadingAuthenticationState();
            //builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddMudBlazorDialog()
                .AddMudServices(mudServicesConfiguration =>
                {
                    mudServicesConfiguration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                    mudServicesConfiguration.SnackbarConfiguration.PreventDuplicates = false;
                    mudServicesConfiguration.SnackbarConfiguration.NewestOnTop = true;
                    mudServicesConfiguration.SnackbarConfiguration.ShowCloseIcon = true;
                    mudServicesConfiguration.SnackbarConfiguration.VisibleStateDuration = 4000;
                    mudServicesConfiguration.SnackbarConfiguration.HideTransitionDuration = 500;
                    mudServicesConfiguration.SnackbarConfiguration.ShowTransitionDuration = 500;
                    mudServicesConfiguration.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
                }).AddHotKeys2();

            builder.Services.AddFluxor(options =>
            {
                options.ScanAssemblies(Assembly.GetExecutingAssembly());
                options.UseReduxDevTools();
            });

            builder.Services.AddHttpClient("ocr", c =>
            {
                c.BaseAddress = new Uri("http://10.33.1.150:8000/ocr/predict-by-file");
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }).AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(30)));
            builder.Services.AddScoped<LocalTimezoneOffset>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddMudExtensions()
                .AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>()
                .AddScoped<LayoutService>()
                .AddScoped<IUserPreferencesService, UserPreferencesService>()
                .AddScoped<IMenuService, MenuService>()
                .AddScoped<InMemoryNotificationService>()
                .AddScoped<INotificationService>(sp =>
                {
                    var service = sp.GetRequiredService<InMemoryNotificationService>();
                    service.Preload();
                    return service;
                });

            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            
            app.UseRouting();
            
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            
            app.Run();
        }
    }
}

