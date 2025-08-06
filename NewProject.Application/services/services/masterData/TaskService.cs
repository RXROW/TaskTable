using Mapster;
using NewProject.Application.DTOs;
using NewProject.Application.services.interfaces.masterData;
using NewProject.Domain.interfaces.masterData;

namespace NewProject.Application.services.services.masterData
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskResponseDto> CreateAsync(CreateTaskDto dto)
        {
            var entity = dto.Adapt<NewProject.Domain.models.masterData.Task>();
            var created = await _repository.CreateAsync(entity);
            return created.Adapt<TaskResponseDto>();
        }

        public async Task<TaskResponseDto?> GetByIdAsync(int taskId)
        {
            var entity = await _repository.GetByIdAsync(taskId);
            return entity?.Adapt<TaskResponseDto>();
        }

        public async Task<IEnumerable<TaskResponseDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Adapt<IEnumerable<TaskResponseDto>>();
        }

        public async Task<IEnumerable<TaskResponseDto>> GetActiveTasksAsync()
        {
            var entities = await _repository.GetActiveTasksAsync();
            return entities.Adapt<IEnumerable<TaskResponseDto>>();
        }

        public async Task<IEnumerable<TaskResponseDto>> GetByGroupIdAsync(int groupId)
        {
            var entities = await _repository.GetByGroupIdAsync(groupId);
            return entities.Adapt<IEnumerable<TaskResponseDto>>();
        }

        public async Task<IEnumerable<TaskResponseDto>> GetByStatusIdAsync(int statusId)
        {
            var entities = await _repository.GetByStatusIdAsync(statusId);
            return entities.Adapt<IEnumerable<TaskResponseDto>>();
        }

        public async Task<IEnumerable<TaskResponseDto>> GetByPriorityIdAsync(int priorityId)
        {
            var entities = await _repository.GetByPriorityIdAsync(priorityId);
            return entities.Adapt<IEnumerable<TaskResponseDto>>();
        }

        public async Task<IEnumerable<TaskResponseDto>> GetByTypeIdAsync(int typeId)
        {
            var entities = await _repository.GetByTypeIdAsync(typeId);
            return entities.Adapt<IEnumerable<TaskResponseDto>>();
        }

        public async Task<IEnumerable<TaskResponseDto>> GetByTenantIdAsync(int tenantId)
        {
            var entities = await _repository.GetByTenantIdAsync(tenantId);
            return entities.Adapt<IEnumerable<TaskResponseDto>>();
        }

        public async Task<IEnumerable<TaskResponseDto>> GetOverdueTasksAsync()
        {
            var entities = await _repository.GetOverdueTasksAsync();
            return entities.Adapt<IEnumerable<TaskResponseDto>>();
        }

        public async Task<IEnumerable<TaskResponseDto>> GetTasksDueTodayAsync()
        {
            var entities = await _repository.GetTasksDueTodayAsync();
            return entities.Adapt<IEnumerable<TaskResponseDto>>();
        }

        public async Task<TaskResponseDto> UpdateAsync(UpdateTaskDto dto)
        {
            var entity = dto.Adapt<NewProject.Domain.models.masterData.Task>();
            var updated = await _repository.UpdateAsync(entity);
            return updated.Adapt<TaskResponseDto>();
        }

        public async Task<bool> DeleteAsync(int taskId)
        {
            return await _repository.DeleteAsync(taskId);
        }

        public async Task<bool> SoftDeleteAsync(int taskId)
        {
            return await _repository.SoftDeleteAsync(taskId);
        }

        public async Task<bool> ExistsAsync(int taskId)
        {
            return await _repository.ExistsAsync(taskId);
        }

        public async Task<bool> ExistsByTitleAsync(string title)
        {
            return await _repository.ExistsByTitleAsync(title);
        }
    }
}
