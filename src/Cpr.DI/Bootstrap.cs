using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Cpr.Data;
using Microsoft.Extensions.DependencyInjection;
using Cpr.Domain;
using Cpr.Domain.LivroCaixa;
using Cpr.Data.Repositories;

namespace Cpr.DI
{
    public class Bootstrap
    {      
      public static void Configure(IServiceCollection services, string conection)
        {
            services.AddDbContext<ApplicationDbContext> (options => 
            options.UseSqlServer(conection));
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //cria o serviço para pegar a entidade de forma genérica
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<LivroCaixa>), typeof(LivroCaixaRepository));
            services.AddScoped(typeof(ArmazenaCategoria));
            services.AddScoped(typeof(ArmazenaLivroCaixa));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
                            
        }
    }
}