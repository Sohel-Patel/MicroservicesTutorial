using eCommers.Core.ServiceContracts;
using eCommers.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommers.Core
{
    
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IUserService,UserService>();
            return services;
        }
    }
       
}
