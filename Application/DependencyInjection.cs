using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    /// <summary>
    /// Utility class contains IoC method.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds MediatR library with all commands and requests.
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
