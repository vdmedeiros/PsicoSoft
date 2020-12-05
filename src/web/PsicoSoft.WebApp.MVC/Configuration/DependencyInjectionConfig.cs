using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PsicoSoft.WebApp.MVC.Extensions;
using PsicoSoft.WebApp.MVC.Services;

namespace PsicoSoft.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}