using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using NewProject.Application.DTOs;
using NewProject.Application.services.interfaces.Refrence;
using NewProject.Domain.interfaces.Refrence;
using NewProject.Domain.models.Refrence;

namespace NewProject.Application.services.Refrence
{
    public class TaskTypeService : ITaskTypeService
    {
        private readonly ITaskTypeRepository _repository;
        public TaskTypeService(ITaskTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskTypeDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Adapt<IEnumerable<TaskTypeDto>>();
        }

        public async Task<TaskTypeDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity.Adapt<TaskTypeDto>();
        }

        public async Task AddAsync(TaskTypeDto taskTypeDto)
        {
            var entity = taskTypeDto.Adapt<TaskType>();
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(TaskTypeDto taskTypeDto)
        {
            var entity = taskTypeDto.Adapt<TaskType>();
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}