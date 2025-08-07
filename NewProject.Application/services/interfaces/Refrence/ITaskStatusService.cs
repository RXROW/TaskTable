using System.Collections.Generic;
using System.Threading.Tasks;
using NewProject.Application.DTOs;

namespace NewProject.Application.services.interfaces.Refrence
{
    public interface ITaskStatusService
    {
        Task<IEnumerable<TaskStatusDto>> GetAllAsync();
        Task<TaskStatusDto> GetByIdAsync(int id);
        Task AddAsync(TaskStatusDto taskStatusDto);
        Task UpdateAsync(TaskStatusDto taskStatusDto);
        Task DeleteAsync(int id);
    }
}