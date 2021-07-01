using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
    public static class BusinessLogicDependencyInjectionExtensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IStudentService, StudentService>();
            serviceCollection.AddScoped<ILessonService, LessonService>();
            serviceCollection.AddScoped<IInvoiceService, InvoiceService>();
            serviceCollection.AddScoped<IHashing, Hashing>();
            return serviceCollection;
        }
    }
}