using Microsoft.Extensions.DependencyInjection;
using NewProject.Domain.models.masterData;
using NewProject.Infrastructure.Reposetries.masterData;
using NewProject.Domain.interfaces.masterData;

namespace NewProject.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ISupportGroupRepository, SupportGroupRepository>();
            services.AddScoped<ISupportGroupMemberRepository, SupportGroupMemberRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            // Register other repositories here
            return services;
        }
    }
}