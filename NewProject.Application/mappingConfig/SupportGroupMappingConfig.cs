using Mapster;
using NewProject.Domain.models.masterData;
using NewProject.Application.DTOs;

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
        }
    }
}