using Mapster;
using NewProject.Domain.models.masterData;
using NewProject.Application.DTOs;
using NewProject.Domain.models.Refrence;

namespace NewProject.Application.mappingConfig
{
    public static class SupportGroupMappingConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<CreateSupportGroupDto, SupportGroup>.NewConfig();
            TypeAdapterConfig<UpdateSupportGroupDto, SupportGroup>.NewConfig();
            TypeAdapterConfig<SupportGroup, SupportGroupResponseDto>.NewConfig();
            TypeAdapterConfig<SupportGroup, SupportGroupListDto>.NewConfig();
            TypeAdapterConfig<TaskType, TaskTypeDto>.NewConfig();
            TypeAdapterConfig<TaskTypeDto, TaskType>.NewConfig();
            TypeAdapterConfig<NewProject.Domain.models.Refrence.TaskStatus, TaskStatusDto>.NewConfig();
            TypeAdapterConfig<TaskStatusDto, NewProject.Domain.models.Refrence.TaskStatus>.NewConfig();
        }
    }
}