using Mapster;
using NewProject.Application.DTOs;
using NewProject.Application.services.interfaces.masterData;
using NewProject.Domain.interfaces.masterData;
using NewProject.Domain.models.masterData;

namespace NewProject.Application.services.services.masterData
{
    public class SupportGroupMemberService : ISupportGroupMemberService
    {
        private readonly ISupportGroupMemberRepository _repository;
        public SupportGroupMemberService(ISupportGroupMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<SupportGroupMemberResponseDto> CreateAsync(CreateSupportGroupMemberDto dto)
        {
            var entity = dto.Adapt<SupportGroupMember>();
            var created = await _repository.CreateAsync(entity);
            return created.Adapt<SupportGroupMemberResponseDto>();
        }

        public async Task<SupportGroupMemberResponseDto?> GetByIdAsync(int memberGroupId)
        {
            var entity = await _repository.GetByIdAsync(memberGroupId);
            return entity?.Adapt<SupportGroupMemberResponseDto>();
        }

        public async Task<IEnumerable<SupportGroupMemberListDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Adapt<IEnumerable<SupportGroupMemberListDto>>();
        }

        public async Task<IEnumerable<SupportGroupMemberListDto>> GetByGroupIdAsync(int groupId)
        {
            var entities = await _repository.GetByGroupIdAsync(groupId);
            return entities.Adapt<IEnumerable<SupportGroupMemberListDto>>();
        }

        public async Task<IEnumerable<SupportGroupMemberListDto>> GetByUserIdAsync(int userId)
        {
            var entities = await _repository.GetByUserIdAsync(userId);
            return entities.Adapt<IEnumerable<SupportGroupMemberListDto>>();
        }

        public async Task<IEnumerable<SupportGroupMemberListDto>> GetActiveMembersAsync(int groupId)
        {
            var entities = await _repository.GetActiveMembersAsync(groupId);
            return entities.Adapt<IEnumerable<SupportGroupMemberListDto>>();
        }

        public async Task<SupportGroupMemberResponseDto> UpdateAsync(int memberGroupId, UpdateSupportGroupMemberDto dto)
        {
            var entity = await _repository.GetByIdAsync(memberGroupId);
            if (entity == null) throw new Exception("SupportGroupMember not found");
            dto.Adapt(entity);
            var updated = await _repository.UpdateAsync(entity);
            return updated.Adapt<SupportGroupMemberResponseDto>();
        }

        public async Task<bool> DeleteAsync(int memberGroupId)
        {
            return await _repository.DeleteAsync(memberGroupId);
        }

        public async Task<bool> SoftDeleteAsync(int memberGroupId)
        {
            return await _repository.SoftDeleteAsync(memberGroupId);
        }
    }
}