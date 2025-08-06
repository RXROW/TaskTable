using NewProject.Application.DTOs;

namespace NewProject.Application.services.interfaces.masterData
{
    public interface ITaskService
    {
        // Create
        Task<TaskResponseDto> CreateAsync(CreateTaskDto dto);
        
        // Read
        Task<TaskResponseDto?> GetByIdAsync(int taskId);
        Task<IEnumerable<TaskResponseDto>> GetAllAsync();
        Task<IEnumerable<TaskResponseDto>> GetActiveTasksAsync();
        Task<IEnumerable<TaskResponseDto>> GetByGroupIdAsync(int groupId);
        Task<IEnumerable<TaskResponseDto>> GetByStatusIdAsync(int statusId);
        Task<IEnumerable<TaskResponseDto>> GetByPriorityIdAsync(int priorityId);
        Task<IEnumerable<TaskResponseDto>> GetByTypeIdAsync(int typeId);
        Task<IEnumerable<TaskResponseDto>> GetByTenantIdAsync(int tenantId);
        Task<IEnumerable<TaskResponseDto>> GetOverdueTasksAsync();
        Task<IEnumerable<TaskResponseDto>> GetTasksDueTodayAsync();
        
        // Update
        Task<TaskResponseDto> UpdateAsync(UpdateTaskDto dto);
        
        // Delete
        Task<bool> DeleteAsync(int taskId); 
        // Existence checks
        Task<bool> ExistsAsync(int taskId);
        Task<bool> ExistsByTitleAsync(string title);
    }
}
