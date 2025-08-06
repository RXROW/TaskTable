using Microsoft.AspNetCore.Mvc;
using NewProject.Application.DTOs;
using NewProject.Application.services.interfaces.masterData;

namespace NewProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetAll()
        {
            var tasks = await _taskService.GetAllAsync();
            return Ok(tasks);
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResponseDto>> GetById(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // GET: api/Task/active
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetActiveTasks()
        {
            var tasks = await _taskService.GetActiveTasksAsync();
            return Ok(tasks);
        }

        // GET: api/Task/group/5
        [HttpGet("group/{groupId}")]
        public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetByGroupId(int groupId)
        {
            var tasks = await _taskService.GetByGroupIdAsync(groupId);
            return Ok(tasks);
        }

        // GET: api/Task/status/5
        [HttpGet("status/{statusId}")]
        public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetByStatusId(int statusId)
        {
            var tasks = await _taskService.GetByStatusIdAsync(statusId);
            return Ok(tasks);
        }

        // GET: api/Task/priority/5
        [HttpGet("priority/{priorityId}")]
        public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetByPriorityId(int priorityId)
        {
            var tasks = await _taskService.GetByPriorityIdAsync(priorityId);
            return Ok(tasks);
        }

        // GET: api/Task/type/5
        [HttpGet("type/{typeId}")]
        public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetByTypeId(int typeId)
        {
            var tasks = await _taskService.GetByTypeIdAsync(typeId);
            return Ok(tasks);
        }

        // GET: api/Task/tenant/5
        [HttpGet("tenant/{tenantId}")]
        public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetByTenantId(int tenantId)
        {
            var tasks = await _taskService.GetByTenantIdAsync(tenantId);
            return Ok(tasks);
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<TaskResponseDto>> Create(CreateTaskDto createTaskDto)
        {
            try
            {
                var createdTask = await _taskService.CreateAsync(createTaskDto);
                return CreatedAtAction(nameof(GetById), new { id = createdTask.TaskID }, createdTask);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating task: {ex.Message}");
            }
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskDto updateTaskDto)
        {
            if (id != updateTaskDto.TaskID)
            {
                return BadRequest("Task ID mismatch");
            }

            try
            {
                var updatedTask = await _taskService.UpdateAsync(updateTaskDto);
                return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating task: {ex.Message}");
            }
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _taskService.ExistsAsync(id);
            if (!exists)
            {
                return NotFound();
            }

            var deleted = await _taskService.DeleteAsync(id);
            if (!deleted)
            {
                return BadRequest("Failed to delete task");
            }

            return NoContent();
        }
    }
}
