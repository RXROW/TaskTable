using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace NewProject.Domain.models.masterData
{
    public class SupportGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupID { get; set; }

        [MaxLength(100)]
        public string GroupName { get; set; }

        public int? DomainID { get; set; }

        public string? Description { get; set; }

        public int? NumberOfMembers { get; set; } = 1;

        public int? LeaderID { get; set; }

        [MaxLength(100)]
        public string? ContactEmail { get; set; }

        public string? EscalationPath { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int? CreatedByUserID { get; set; }

        public DateTime LastUpdateDate { get; set; } = DateTime.Now;

        public int? LastUpdateUserID { get; set; }

        public int ModCount { get; set; } = 0;

        public ICollection<SupportGroupMember> Members { get; set; } = new List<SupportGroupMember>();
    }
}