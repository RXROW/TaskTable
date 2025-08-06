using Mapster;
using NewProject.Application.DTOs;
using NewProject.Application.services.interfaces.masterData;
using NewProject.Domain.models.masterData;

namespace NewProject.Application.services.masterData
{
    public class SupportGroupService : ISupportGroupService
    {
        private readonly ISupportGroupRepository _repository;
        public SupportGroupService(ISupportGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<SupportGroupResponseDto> CreateAsync(CreateSupportGroupDto dto)
        {
            var entity = dto.Adapt<SupportGroup>();
            var created = await _repository.CreateAsync(entity);
            return created.Adapt<SupportGroupResponseDto>();
        }

        public async Task<SupportGroupResponseDto?> GetByIdAsync(int groupId)
        {
            var entity = await _repository.GetByIdAsync(groupId);
            return entity?.Adapt<SupportGroupResponseDto>();
        }

        public async Task<IEnumerable<SupportGroupListDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Adapt<IEnumerable<SupportGroupListDto>>();
        }

        public async Task<SupportGroupResponseDto> UpdateAsync(int groupId, UpdateSupportGroupDto dto)
        {
            var entity = await _repository.GetByIdAsync(groupId);
            if (entity == null) throw new Exception("SupportGroup not found");
            dto.Adapt(entity); // Map updated fields onto the entity
            var updated = await _repository.UpdateAsync(entity);
            return updated.Adapt<SupportGroupResponseDto>();
        }

        public async Task<bool> DeleteAsync(int groupId)
        {
            return await _repository.DeleteAsync(groupId);
        }

        public async Task<bool> SoftDeleteAsync(int groupId)
        {
            return await _repository.SoftDeleteAsync(groupId);
        }
    }
}