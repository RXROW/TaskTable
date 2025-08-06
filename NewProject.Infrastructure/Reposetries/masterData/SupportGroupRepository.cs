using Microsoft.EntityFrameworkCore;
using NewProject.Domain.models.masterData;
using NewProject.Infrastructure.Data;

namespace NewProject.Infrastructure.Reposetries.masterData
{
    public class SupportGroupRepository : ISupportGroupRepository
    {
        private readonly AppDbContext _context;
        public SupportGroupRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SupportGroup> CreateAsync(SupportGroup supportGroup)
        {
            _context.SupportGroups.Add(supportGroup);
            await _context.SaveChangesAsync();
            return supportGroup;
        }

        public async Task<SupportGroup?> GetByIdAsync(int groupId)
        {
            return await _context.SupportGroups.FindAsync(groupId);
        }

        public async Task<IEnumerable<SupportGroup>> GetAllAsync()
        {
            return await _context.SupportGroups.ToListAsync();
        }

        public async Task<IEnumerable<SupportGroup>> GetActiveGroupsAsync()
        {
            return await _context.SupportGroups.Where(g => g.IsActive).ToListAsync();
        }

        public async Task<SupportGroup?> GetByGroupNameAsync(string groupName)
        {
            return await _context.SupportGroups.FirstOrDefaultAsync(g => g.GroupName == groupName);
        }

        public async Task<SupportGroup> UpdateAsync(SupportGroup supportGroup)
        {
            _context.SupportGroups.Update(supportGroup);
            await _context.SaveChangesAsync();
            return supportGroup;
        }

        public async Task<bool> DeleteAsync(int groupId)
        {
            var group = await _context.SupportGroups.FindAsync(groupId);
            if (group == null) return false;
            _context.SupportGroups.Remove(group);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteAsync(int groupId)
        {
            var group = await _context.SupportGroups.FindAsync(groupId);
            if (group == null) return false;
            group.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SupportGroup>> GetByDomainIdAsync(int domainId)
        {
            return await _context.SupportGroups.Where(g => g.DomainID == domainId).ToListAsync();
        }

        public async Task<IEnumerable<SupportGroup>> GetByLeaderIdAsync(int leaderId)
        {
            return await _context.SupportGroups.Where(g => g.LeaderID == leaderId).ToListAsync();
        }

        public async Task<bool> ExistsAsync(int groupId)
        {
            return await _context.SupportGroups.AnyAsync(g => g.GroupID == groupId);
        }

        public async Task<bool> ExistsByNameAsync(string groupName)
        {
            return await _context.SupportGroups.AnyAsync(g => g.GroupName == groupName);
        }
    }
}