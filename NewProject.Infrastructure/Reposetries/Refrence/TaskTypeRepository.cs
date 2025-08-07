using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewProject.Domain.models.Refrence;
using NewProject.Domain.interfaces.Refrence;
using NewProject.Infrastructure.Data;

namespace NewProject.Infrastructure.Reposetries.Refrence
{
    public class TaskTypeRepository : ITaskTypeRepository
    {
        private readonly AppDbContext _context;

        public TaskTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskType>> GetAllAsync()
        {
            return await _context.Set<TaskType>().ToListAsync();
        }

        public async Task<TaskType> GetByIdAsync(int id)
        {
            return await _context.Set<TaskType>().FindAsync(id);
        }

        public async Task AddAsync(TaskType taskType)
        {
            await _context.Set<TaskType>().AddAsync(taskType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskType taskType)
        {
            _context.Set<TaskType>().Update(taskType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<TaskType>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TaskType>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}