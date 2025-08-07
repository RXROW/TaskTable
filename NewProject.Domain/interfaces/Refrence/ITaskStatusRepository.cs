using System.Collections.Generic;
using System.Threading.Tasks;
using NewProject.Domain.models.Refrence;

namespace NewProject.Domain.interfaces.Refrence
{
    public interface ITaskStatusRepository
    {
        Task<IEnumerable<NewProject.Domain.models.Refrence.TaskStatus>> GetAllAsync();
        Task<NewProject.Domain.models.Refrence.TaskStatus> GetByIdAsync(int id);
        Task AddAsync(NewProject.Domain.models.Refrence.TaskStatus taskStatus);
        Task UpdateAsync(NewProject.Domain.models.Refrence.TaskStatus taskStatus);
        Task DeleteAsync(int id);
    }
}