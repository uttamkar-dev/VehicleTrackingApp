using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Application.Interfaces;
using VehicleTracking.Infrastructure.Context;
using VehicleTracking.Infrastructure.Repositories;

namespace VehicleTracking.Infrastructure.Helper
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInsfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IVehicleGeoLocationRepository, VehicleGeoLocationRepository>();
            return services;
        }
    }
}
