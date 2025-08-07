using Microsoft.Extensions.DependencyInjection;
using NewProject.Domain.models.masterData;
using NewProject.Infrastructure.Reposetries.masterData;
using NewProject.Domain.interfaces.masterData;
using NewProject.Domain.interfaces.Refrence;
using NewProject.Infrastructure.Reposetries.Refrence;

namespace NewProject.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ISupportGroupRepository, SupportGroupRepository>();
            services.AddScoped<ISupportGroupMemberRepository, SupportGroupMemberRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskTypeRepository, TaskTypeRepository>();
            services.AddScoped<ITaskStatusRepository, TaskStatusRepository>();
           
            // Register other repositories here
            return services;
        }
    }
}