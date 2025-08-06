using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewProject.Domain.models.masterData
{
    public class SupportGroupMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberGroupID { get; set; }

        [Required]
        public int GroupID { get; set; }
        [ForeignKey("GroupID")]
        public SupportGroup SupportGroup { get; set; } = null!;

        [Required]
        public int UserID { get; set; } // Foreign key to User table (not implemented here)

        [Required]
        public DateTime JoinedDate { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;

        [MaxLength(50)]
        public string? RoleInGroup { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int? CreatedByUserID { get; set; }

        [Required]
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;

        public int? LastUpdateUserID { get; set; }

        [Required]
        public int ModCount { get; set; } = 0;
    }
}