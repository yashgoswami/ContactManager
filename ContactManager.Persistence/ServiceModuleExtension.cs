using ContactManager.Application.Contracts;
using ContactManager.Application.Contracts.Contact;
using ContactManager.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManager.Persistence
{
    public static class ServiceModuleExtentions
    {
        public static void RegisterInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddTransient<IContactRepository, ContactRepository>();
        }
    }
}
