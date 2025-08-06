using System.ComponentModel.DataAnnotations;

namespace NewProject.Application.DTOs
{
    public class CreateTaskDto
    {
        [Required]
        public int TenantID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public int TaskTypeID { get; set; }

        [Required]
        public int TaskStageID { get; set; }

        [Required]
        public int TaskStatusID { get; set; }

        [Required]
        public int TaskPriorityID { get; set; }

        [Required]
        public int ModuleID { get; set; }

        [StringLength(100)]
        public string? ModuleName { get; set; }

        public int? ModuleEntityID { get; set; }

        [Required]
        public int GroupID { get; set; }

        public DateTime? ActualStartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? ActualEndDate { get; set; }

        [StringLength(500)]
        public string? Comments { get; set; }

        public bool IsActive { get; set; } = true;
    }

    public class UpdateTaskDto
    {
        [Required]
        public int TaskID { get; set; }

        [Required]
        public int TenantID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public int TaskTypeID { get; set; }

        [Required]
        public int TaskStageID { get; set; }

        [Required]
        public int TaskStatusID { get; set; }

        [Required]
        public int TaskPriorityID { get; set; }

        [Required]
        public int ModuleID { get; set; }

        [StringLength(100)]
        public string? ModuleName { get; set; }

        public int? ModuleEntityID { get; set; }

        [Required]
        public int GroupID { get; set; }

        public DateTime? ActualStartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? ActualEndDate { get; set; }

        [StringLength(500)]
        public string? Comments { get; set; }

        public bool IsActive { get; set; } = true;
    }

    public class TaskResponseDto
    {
        public int TaskID { get; set; }
        public int TenantID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int TaskTypeID { get; set; }
        public int TaskStageID { get; set; }
        public int TaskStatusID { get; set; }
        public int TaskPriorityID { get; set; }
        public int ModuleID { get; set; }
        public string? ModuleName { get; set; }
        public int? ModuleEntityID { get; set; }
        public int GroupID { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public string? Comments { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }

    public class TaskListDto
    {
        public int TaskID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int TaskStatusID { get; set; }
        public int TaskPriorityID { get; set; }
        public int GroupID { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
