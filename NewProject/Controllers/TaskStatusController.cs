using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewProject.Application.DTOs;
using NewProject.Application.services.interfaces.Refrence;

namespace NewProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskStatusController : ControllerBase
    {
        private readonly ITaskStatusService _taskStatusService;
        public TaskStatusController(ITaskStatusService taskStatusService)
        {
            _taskStatusService = taskStatusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskStatusDto>>> GetAll()
        {
            var result = await _taskStatusService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskStatusDto>> GetById(int id)
        {
            var result = await _taskStatusService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(TaskStatusDto dto)
        {
            await _taskStatusService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.TaskStatusID }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TaskStatusDto dto)
        {
            if (id != dto.TaskStatusID)
                return BadRequest();
            await _taskStatusService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _taskStatusService.DeleteAsync(id);
            return NoContent();
        }
    }
}