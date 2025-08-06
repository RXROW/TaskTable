using Microsoft.EntityFrameworkCore;
using NewProject.Domain.models.masterData;
using NewProject.Domain.interfaces.masterData;
using NewProject.Infrastructure.Data;

namespace NewProject.Infrastructure.Reposetries.masterData
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<NewProject.Domain.models.masterData.Task> CreateAsync(NewProject.Domain.models.masterData.Task task)
        {
            _context.Set<NewProject.Domain.models.masterData.Task>().Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<NewProject.Domain.models.masterData.Task?> GetByIdAsync(int taskId)
        {
            return await _context.Set<NewProject.Domain.models.masterData.Task>().FindAsync(taskId);
        }

        public async Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetAllAsync()
        {
            return await _context.Set<NewProject.Domain.models.masterData.Task>().ToListAsync();
        }

        public async Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetActiveTasksAsync()
        {
            return await _context.Set<NewProject.Domain.models.masterData.Task>().Where(t => t.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetByGroupIdAsync(int groupId)
        {
            return await _context.Set<NewProject.Domain.models.masterData.Task>().Where(t => t.GroupID == groupId).ToListAsync();
        }

        public async Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetByStatusIdAsync(int statusId)
        {
            return await _context.Set<NewProject.Domain.models.masterData.Task>().Where(t => t.TaskStatusID == statusId).ToListAsync();
        }

        public async Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetByPriorityIdAsync(int priorityId)
        {
            return await _context.Set<NewProject.Domain.models.masterData.Task>().Where(t => t.TaskPriorityID == priorityId).ToListAsync();
        }

        public async Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetByTypeIdAsync(int typeId)
        {
            return await _context.Set<NewProject.Domain.models.masterData.Task>().Where(t => t.TaskTypeID == typeId).ToListAsync();
        }

        public async Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetByTenantIdAsync(int tenantId)
        {
            return await _context.Set<NewProject.Domain.models.masterData.Task>().Where(t => t.TenantID == tenantId).ToListAsync();
        }

        public async Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetOverdueTasksAsync()
        {
            var today = DateTime.Today;
            return await _context.Set<NewProject.Domain.models.masterData.Task>()
                .Where(t => t.DueDate.HasValue && t.DueDate.Value.Date < today && t.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<NewProject.Domain.models.masterData.Task>> GetTasksDueTodayAsync()
        {
            var today = DateTime.Today;
            return await _context.Set<NewProject.Domain.models.masterData.Task>()
                .Where(t => t.DueDate.HasValue && t.DueDate.Value.Date == today && t.IsActive)
                .ToListAsync();
        }

        public async Task<NewProject.Domain.models.masterData.Task> UpdateAsync(NewProject.Domain.models.masterData.Task task)
        {
            _context.Set<NewProject.Domain.models.masterData.Task>().Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteAsync(int taskId)
        {
            var task = await _context.Set<NewProject.Domain.models.masterData.Task>().FindAsync(taskId);
            if (task == null) return false;
            _context.Set<NewProject.Domain.models.masterData.Task>().Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteAsync(int taskId)
        {
            var task = await _context.Set<NewProject.Domain.models.masterData.Task>().FindAsync(taskId);
            if (task == null) return false;
            task.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int taskId)
        {
            return await _context.Set<NewProject.Domain.models.masterData.Task>().AnyAsync(t => t.TaskID == taskId);
        }

        public async Task<bool> ExistsByTitleAsync(string title)
        {
            return await _context.Set<NewProject.Domain.models.masterData.Task>().AnyAsync(t => t.Title == title);
        }
    }
}
