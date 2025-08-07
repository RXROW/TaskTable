using NewProject.Domain.models.Refrence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewProject.Domain.interfaces.Refrence
{
    public interface ITaskTypeRepository
    {
        Task<IEnumerable<TaskType>> GetAllAsync();
        Task<TaskType> GetByIdAsync(int id);
        Task AddAsync(TaskType taskType);
        Task UpdateAsync(TaskType taskType);
        Task DeleteAsync(int id);
    }
}