using NewProject.Domain.models.masterData;

namespace NewProject.Domain.interfaces.masterData
{
    public interface ITaskRepository
    {
        // Create
        Task<NewProject.Domain.models.masterData.Task> CreateAsync(NewProject.Domain.models.masterData.Task task);
        
        // Read
        Task<NewProject.Domain.models.masterData.Task?> GetByIdAsync(int taskId);
        Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetAllAsync();
        Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetActiveTasksAsync();
        Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetByGroupIdAsync(int groupId);
        Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetByStatusIdAsync(int statusId);
        Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetByPriorityIdAsync(int priorityId);
        Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetByTypeIdAsync(int typeId);
        Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetByTenantIdAsync(int tenantId);
        Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetOverdueTasksAsync();
        Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetTasksDueTodayAsync();
        
        // Update
        Task<NewProject.Domain.models.masterData.Task> UpdateAsync(NewProject.Domain.models.masterData.Task task);
        
        // Delete
        Task<bool> DeleteAsync(int taskId);
        Task<bool> SoftDeleteAsync(int taskId);
        
        // Existence checks
        Task<bool> ExistsAsync(int taskId);
        Task<bool> ExistsByTitleAsync(string title);
    }
}
