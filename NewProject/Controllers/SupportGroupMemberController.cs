using Microsoft.AspNetCore.Mvc;
using NewProject.Application.services.interfaces.masterData;
using NewProject.Application.DTOs;

namespace NewProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupportGroupMemberController : ControllerBase
    {
        private readonly ISupportGroupMemberService _service;
        public SupportGroupMemberController(ISupportGroupMemberService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportGroupMemberListDto>>> GetAll()
        {
            var members = await _service.GetAllAsync();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupportGroupMemberResponseDto>> GetById(int id)
        {
            var member = await _service.GetByIdAsync(id);
            if (member == null) return NotFound();
            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<SupportGroupMemberResponseDto>> Create([FromBody] CreateSupportGroupMemberDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.MemberGroupID }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SupportGroupMemberResponseDto>> Update(int id, [FromBody] UpdateSupportGroupMemberDto dto)
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
