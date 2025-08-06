using System.ComponentModel.DataAnnotations;

namespace NewProject.Application.DTOs
{
    // DTO for creating a new support group
    public class CreateSupportGroupDto
    {
        [Required]
        [MaxLength(100)]
        public string GroupName { get; set; } = string.Empty;

        public int? DomainID { get; set; }

        public string? Description { get; set; }

        public int? NumberOfMembers { get; set; } = 1;

        public int? LeaderID { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string? ContactEmail { get; set; }

        public string? EscalationPath { get; set; }

        public bool IsActive { get; set; } = true;
    }

    // DTO for updating an existing support group
    public class UpdateSupportGroupDto
    {
        [Required]
        [MaxLength(100)]
        public string GroupName { get; set; } = string.Empty;

        public int? DomainID { get; set; }

        public string? Description { get; set; }

        public int? NumberOfMembers { get; set; }

        public int? LeaderID { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string? ContactEmail { get; set; }

        public string? EscalationPath { get; set; }

        public bool IsActive { get; set; }
    }

    // DTO for returning support group data
    public class SupportGroupResponseDto
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public int? DomainID { get; set; }
        public string? Description { get; set; }
        public int? NumberOfMembers { get; set; }
        public int? LeaderID { get; set; }
        public string? ContactEmail { get; set; }
        public string? EscalationPath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CreatedByUserID { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int? LastUpdateUserID { get; set; }
        public int ModCount { get; set; }
    }

    // DTO for listing support groups (simplified version)
    public class SupportGroupListDto
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public int? DomainID { get; set; }
        public string? Description { get; set; }
        public int? NumberOfMembers { get; set; }
        public int? LeaderID { get; set; }
        public string? ContactEmail { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
} 