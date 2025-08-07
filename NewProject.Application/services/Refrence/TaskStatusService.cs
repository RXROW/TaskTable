using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using NewProject.Application.DTOs;
using NewProject.Application.services.interfaces.Refrence;
using NewProject.Domain.interfaces.Refrence;
using NewProject.Domain.models.Refrence;

namespace NewProject.Application.services.Refrence
{
    public class TaskStatusService : ITaskStatusService
    {
        private readonly ITaskStatusRepository _repository;
        public TaskStatusService(ITaskStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskStatusDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Adapt<IEnumerable<TaskStatusDto>>();
        }

        public async Task<TaskStatusDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity.Adapt<TaskStatusDto>();
        }

        public async Task AddAsync(TaskStatusDto taskStatusDto)
        {
            var entity = taskStatusDto.Adapt<NewProject.Domain.models.Refrence.TaskStatus>();
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(TaskStatusDto taskStatusDto)
        {
            var entity = taskStatusDto.Adapt<NewProject.Domain.models.Refrence.TaskStatus>();
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}