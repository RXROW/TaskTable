using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewProject.Domain.models.masterData
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskID { get; set; }

        [Required]
        public int TenantID { get; set; } = 1;

        [Required]
        [MaxLength(250)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public int TaskTypeID { get; set; } = 0;

        [Required]
        public int TaskStageID { get; set; }

        [Required]
        public int TaskStatusID { get; set; } = 1;

        [Required]
        public int TaskPriorityID { get; set; } = 2;

        public int? ModuleID { get; set; }

        [MaxLength(250)]
        public string? ModuleName { get; set; }

        public int? ModuleEntityID { get; set; }

        public int? GroupID { get; set; }
        [ForeignKey("GroupID")]
        public SupportGroup? SupportGroup { get; set; }

        [Required]
        public DateTime ActualStartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? ActualEndDate { get; set; }

        public string? Comments { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public int CreatedByUserID { get; set; } = 0;

        [Required]
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;

        [Required]
        public int LastUpdateUserID { get; set; } = 0;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public int ModCount { get; set; } = 0;
    }
}
