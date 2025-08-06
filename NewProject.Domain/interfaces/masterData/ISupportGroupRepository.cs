using NewProject.Domain.models.masterData;

namespace NewProject.Domain.models.masterData
{
    public interface ISupportGroupRepository
    {
        // Create
        Task<SupportGroup> CreateAsync(SupportGroup supportGroup);
        
        // Read
        Task<SupportGroup?> GetByIdAsync(int groupId);
        Task<IEnumerable<SupportGroup>> GetAllAsync();
        Task<IEnumerable<SupportGroup>> GetActiveGroupsAsync();
        Task<SupportGroup?> GetByGroupNameAsync(string groupName);
        
        // Update
        Task<SupportGroup> UpdateAsync(SupportGroup supportGroup);
        
        // Delete
        Task<bool> DeleteAsync(int groupId);
        Task<bool> SoftDeleteAsync(int groupId);
        
        // Additional query methods
        Task<IEnumerable<SupportGroup>> GetByDomainIdAsync(int domainId);
        Task<IEnumerable<SupportGroup>> GetByLeaderIdAsync(int leaderId);
        Task<bool> ExistsAsync(int groupId);
        Task<bool> ExistsByNameAsync(string groupName);
    }
} 