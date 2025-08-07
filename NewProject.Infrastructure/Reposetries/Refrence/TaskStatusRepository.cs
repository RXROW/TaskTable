using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewProject.Domain.models.Refrence;
using NewProject.Domain.interfaces.Refrence;
using NewProject.Infrastructure.Data;

namespace NewProject.Infrastructure.Reposetries.Refrence
{
    public class TaskStatusRepository : ITaskStatusRepository
    {
        private readonly AppDbContext _context;
        public TaskStatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NewProject.Domain.models.Refrence.TaskStatus>> GetAllAsync()
        {
            return await _context.Set<NewProject.Domain.models.Refrence.TaskStatus>().ToListAsync();
        }

        public async Task<NewProject.Domain.models.Refrence.TaskStatus> GetByIdAsync(int id)
        {
            return await _context.Set<NewProject.Domain.models.Refrence.TaskStatus>().FindAsync(id);
        }

        public async Task AddAsync(NewProject.Domain.models.Refrence.TaskStatus taskStatus)
        {
            await _context.Set<NewProject.Domain.models.Refrence.TaskStatus>().AddAsync(taskStatus);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NewProject.Domain.models.Refrence.TaskStatus taskStatus)
        {
            _context.Set<NewProject.Domain.models.Refrence.TaskStatus>().Update(taskStatus);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<NewProject.Domain.models.Refrence.TaskStatus>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<NewProject.Domain.models.Refrence.TaskStatus>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}