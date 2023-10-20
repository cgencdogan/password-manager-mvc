using Business.Abstract;
using Business.Concrete;
using Business.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business;
public static class DependencyInjection {
    public static IServiceCollection AddBusiness(this IServiceCollection services) {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ISavedPasswordService, SavedPasswordService>();

        services.AddSingleton<IEncryption, AesEncryption>();

        return services;
    }
}
