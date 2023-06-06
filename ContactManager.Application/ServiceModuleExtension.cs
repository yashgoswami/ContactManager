using ContactManager.Application.Contracts.Contact;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManager.Application
{
    public static class ServiceModuleExtentions
    {
        public static void RegisterCoreServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IContactService, ContactService>();
        }
    }
}
