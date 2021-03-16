using Application.Interfaces.ApplicationDatabaseContext;
using DatabaseAcces.Context.InterviewContextPartial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseAcces
{
    public static class DependencyInjection
    {
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
