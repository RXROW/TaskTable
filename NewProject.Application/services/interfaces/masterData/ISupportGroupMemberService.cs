using NewProject.Application.DTOs;

namespace NewProject.Application.services.interfaces.masterData
{
    public interface ISupportGroupMemberService
    {
        Task<SupportGroupMemberResponseDto> CreateAsync(CreateSupportGroupMemberDto dto);
        Task<SupportGroupMemberResponseDto?> GetByIdAsync(int memberGroupId);
        Task<IEnumerable<SupportGroupMemberListDto>> GetAllAsync();
        Task<IEnumerable<SupportGroupMemberListDto>> GetByGroupIdAsync(int groupId);
        Task<IEnumerable<SupportGroupMemberListDto>> GetByUserIdAsync(int userId);
        Task<IEnumerable<SupportGroupMemberListDto>> GetActiveMembersAsync(int groupId);
        Task<SupportGroupMemberResponseDto> UpdateAsync(int memberGroupId, UpdateSupportGroupMemberDto dto);
        Task<bool> DeleteAsync(int memberGroupId);
        Task<bool> SoftDeleteAsync(int memberGroupId);
    }
}