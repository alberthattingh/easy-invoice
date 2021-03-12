using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceDependencyInjectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<DbContext, EasyInvoiceContext>();
            serviceCollection.AddScoped<IUsersRepository, UsersRepository>();
            serviceCollection.AddScoped<IStudentsRepository, StudentsRepository>();
            serviceCollection.AddScoped<ILessonsRepository, LessonsRepository>();
            serviceCollection.AddScoped<IInvoiceRepository, InvoiceRepository>();
            serviceCollection.AddScoped<IClassRepository, ClassRepository>();
            return serviceCollection;
        }
    }
}