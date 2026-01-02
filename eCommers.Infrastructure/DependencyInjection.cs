using eCommers.Core.RepositoryContracts;
using eCommers.InfraStructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommers.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service)
        {
            //TO DO: Add Services to IOc container
            //infrastructure often include daTa access, caching and other low level components.
            service.AddTransient<IUserRepository,UserRepository>();
            return service;
        }
    }
}