using NewProject.Domain.models.masterData;

namespace NewProject.Domain.interfaces.masterData
{
    public interface ISupportGroupMemberRepository
    {
        // Create
        Task<SupportGroupMember> CreateAsync(SupportGroupMember member);

        // Read
        Task<SupportGroupMember?> GetByIdAsync(int memberGroupId);
        Task<IEnumerable<SupportGroupMember>> GetAllAsync();
        Task<IEnumerable<SupportGroupMember>> GetByGroupIdAsync(int groupId);
        Task<IEnumerable<SupportGroupMember>> GetByUserIdAsync(int userId);
        Task<IEnumerable<SupportGroupMember>> GetActiveMembersAsync(int groupId);

        // Update
        Task<SupportGroupMember> UpdateAsync(SupportGroupMember member);

        // Delete
        Task<bool> DeleteAsync(int memberGroupId);
        Task<bool> SoftDeleteAsync(int memberGroupId);

        // Existence checks
        Task<bool> ExistsAsync(int memberGroupId);
    }
}