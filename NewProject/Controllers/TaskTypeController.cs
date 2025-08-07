using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewProject.Application.DTOs;
using NewProject.Application.services.interfaces.Refrence;

namespace NewProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskTypeController : ControllerBase
    {
        private readonly ITaskTypeService _taskTypeService;
        public TaskTypeController(ITaskTypeService taskTypeService)
        {
            _taskTypeService = taskTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskTypeDto>>> GetAll()
        {
            var result = await _taskTypeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskTypeDto>> GetById(int id)
        {
            var result = await _taskTypeService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(TaskTypeDto dto)
        {
            await _taskTypeService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.TaskTypeID }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TaskTypeDto dto)
        {
            if (id != dto.TaskTypeID)
                return BadRequest();
            await _taskTypeService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _taskTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}