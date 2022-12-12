using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Domain.Models.AlunoNS.Interfaces;
using Data.Repositories;
using Domain.EntregaNS.Interfaces;
using Domain.AlunoNS.Interfaces;
using Domain.AlunoNS.Service;
using Domain.EntregaNS.Service;

namespace IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AlunoContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IEntregaRepository, EntregaRepository>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IEntregaService, EntregaService>();
            //services.AddScoped<IQueueService, QueueService>();
            return services;
        }
    }
}