using Application.Interfaces.ApplicationDatabaseContext;
using DatabaseAcces.Context.InterviewContextPartial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseAcces
{
    /// <summary>
    /// Utility class contains IoC method
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// This method adds MS SQL SERVER to IoC contaner
        /// </summary>
        /// <param name="services">contaner</param>
        /// <param name="configuration">app configuration</param>
        public static void AddInterviewContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InterviewContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(InterviewContext).Assembly.FullName)
            ));

            services.AddScoped<IInterviewContext>(provider => provider.GetService<InterviewContext>());
        }
    }
}
