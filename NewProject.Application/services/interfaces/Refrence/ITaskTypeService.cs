using System.Collections.Generic;
using System.Threading.Tasks;
using NewProject.Application.DTOs;

namespace NewProject.Application.services.interfaces.Refrence
{
    public interface ITaskTypeService
    {
        Task<IEnumerable<TaskTypeDto>> GetAllAsync();
        Task<TaskTypeDto> GetByIdAsync(int id);
        Task AddAsync(TaskTypeDto taskTypeDto);
        Task UpdateAsync(TaskTypeDto taskTypeDto);
        Task DeleteAsync(int id);
    }
}