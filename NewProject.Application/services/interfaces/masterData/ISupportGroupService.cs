using NewProject.Application.DTOs;

namespace NewProject.Application.services.interfaces.masterData
{
    public interface ISupportGroupService
    {
        Task<SupportGroupResponseDto> CreateAsync(CreateSupportGroupDto dto);
        Task<SupportGroupResponseDto?> GetByIdAsync(int groupId);
        Task<IEnumerable<SupportGroupListDto>> GetAllAsync();
        Task<SupportGroupResponseDto> UpdateAsync(int groupId, UpdateSupportGroupDto dto);
        Task<bool> DeleteAsync(int groupId);
        Task<bool> SoftDeleteAsync(int groupId);
    }
}