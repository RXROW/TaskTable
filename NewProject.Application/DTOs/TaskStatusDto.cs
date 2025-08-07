namespace NewProject.Application.DTOs
{
    public class TaskStatusDto
    {
        public int TaskStatusID { get; set; }
        public int? TenantID { get; set; }
        public string TaskStatusName { get; set; }
        public string Language { get; set; }
    }
}