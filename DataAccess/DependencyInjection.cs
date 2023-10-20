using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.Contexts;
using DataAccess.Concrete.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;
public static class DependencyInjection {
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISavedPasswordRepository, SavedPasswordRepository>();

        services.AddDbContext<MsDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("PasswordManagerMSSQL"));
        });

        return services;
    }
}