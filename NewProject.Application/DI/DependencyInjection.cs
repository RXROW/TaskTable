using Microsoft.Extensions.DependencyInjection;
using NewProject.Application.services.interfaces.masterData;
using NewProject.Application.services.masterData;
using NewProject.Application.services.services.masterData;

namespace NewProject.Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ISupportGroupService, SupportGroupService>();
            services.AddScoped<ISupportGroupMemberService, SupportGroupMemberService>();
            services.AddScoped<ITaskService, TaskService>();
            // Register other services here
            return services;
        }
    }
} 