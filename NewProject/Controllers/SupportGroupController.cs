using Microsoft.AspNetCore.Mvc;
using NewProject.Application.services.interfaces.masterData;
using NewProject.Application.DTOs;

namespace NewProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupportGroupController : ControllerBase
    {
        private readonly ISupportGroupService _service;
        public SupportGroupController(ISupportGroupService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportGroupListDto>>> GetAll()
        {
            var groups = await _service.GetAllAsync();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupportGroupResponseDto>> GetById(int id)
        {
            var group = await _service.GetByIdAsync(id);
            if (group == null) return NotFound();
            return Ok(group);
        }

        [HttpPost]
        public async Task<ActionResult<SupportGroupResponseDto>> Create([FromBody] CreateSupportGroupDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.GroupID }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SupportGroupResponseDto>> Update(int id, [FromBody] UpdateSupportGroupDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var updated = await _service.UpdateAsync(id, dto);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}