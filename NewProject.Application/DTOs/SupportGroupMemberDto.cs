using System.ComponentModel.DataAnnotations;

namespace NewProject.Application.DTOs
{
    // DTO for creating a new support group member
    public class CreateSupportGroupMemberDto
    {
        [Required]
        public int GroupID { get; set; }
        [Required]
        public int UserID { get; set; }
        public DateTime? JoinedDate { get; set; }
        public bool IsActive { get; set; } = true;
        [MaxLength(50)]
        public string? RoleInGroup { get; set; }
    }

    // DTO for updating an existing support group member
    public class UpdateSupportGroupMemberDto
    {
        public DateTime? JoinedDate { get; set; }
        public bool IsActive { get; set; }
        [MaxLength(50)]
        public string? RoleInGroup { get; set; }
    }

    // DTO for returning support group member data
    public class SupportGroupMemberResponseDto
    {
        public int MemberGroupID { get; set; }
        public int GroupID { get; set; }
        public int UserID { get; set; }
        public DateTime JoinedDate { get; set; }
        public bool IsActive { get; set; }
        public string? RoleInGroup { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CreatedByUserID { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int? LastUpdateUserID { get; set; }
        public int ModCount { get; set; }
    }

    // DTO for listing support group members (simplified version)
    public class SupportGroupMemberListDto
    {
        public int MemberGroupID { get; set; }
        public int GroupID { get; set; }
        public int UserID { get; set; }
        public bool IsActive { get; set; }
        public string? RoleInGroup { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}