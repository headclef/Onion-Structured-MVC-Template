using Application.Repositories.Abstract;
using Infrastructure.Services.Abstract;
using Infrastructure.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.Concrete;

namespace Infrastructure.Registrations
{
    public static class Registry 
    {
        #region Methods
        public static void RegisterRepositories(this IServiceCollection repositories)
        {
            // Registering Repositories
            repositories.AddScoped<IUserRepository, UserRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            // Registering Services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
        }
        #endregion
    }
}