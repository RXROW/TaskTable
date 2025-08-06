using Microsoft.EntityFrameworkCore;
using NewProject.Domain.models.masterData;
using NewProject.Domain.interfaces.masterData;
using NewProject.Infrastructure.Data;

namespace NewProject.Infrastructure.Reposetries.masterData
{
    public class SupportGroupMemberRepository : ISupportGroupMemberRepository
    {
        private readonly AppDbContext _context;
        public SupportGroupMemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SupportGroupMember> CreateAsync(SupportGroupMember member)
        {
            _context.Set<SupportGroupMember>().Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<SupportGroupMember?> GetByIdAsync(int memberGroupId)
        {
            return await _context.Set<SupportGroupMember>().FindAsync(memberGroupId);
        }

        public async Task<IEnumerable<SupportGroupMember>> GetAllAsync()
        {
            return await _context.Set<SupportGroupMember>().ToListAsync();
        }

        public async Task<IEnumerable<SupportGroupMember>> GetByGroupIdAsync(int groupId)
        {
            return await _context.Set<SupportGroupMember>().Where(m => m.GroupID == groupId).ToListAsync();
        }

        public async Task<IEnumerable<SupportGroupMember>> GetByUserIdAsync(int userId)
        {
            return await _context.Set<SupportGroupMember>().Where(m => m.UserID == userId).ToListAsync();
        }

        public async Task<IEnumerable<SupportGroupMember>> GetActiveMembersAsync(int groupId)
        {
            return await _context.Set<SupportGroupMember>().Where(m => m.GroupID == groupId && m.IsActive).ToListAsync();
        }

        public async Task<SupportGroupMember> UpdateAsync(SupportGroupMember member)
        {
            _context.Set<SupportGroupMember>().Update(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<bool> DeleteAsync(int memberGroupId)
        {
            var member = await _context.Set<SupportGroupMember>().FindAsync(memberGroupId);
            if (member == null) return false;
            _context.Set<SupportGroupMember>().Remove(member);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteAsync(int memberGroupId)
        {
            var member = await _context.Set<SupportGroupMember>().FindAsync(memberGroupId);
            if (member == null) return false;
            member.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int memberGroupId)
        {
            return await _context.Set<SupportGroupMember>().AnyAsync(m => m.MemberGroupID == memberGroupId);
        }
    }
}