namespace NewProject.Domain.models.Refrence
{
    public class TaskStatus
    {
        public int TaskStatusID { get; set; }
        public int? TenantID { get; set; }
        public string TaskStatusName { get; set; }
        public string Language { get; set; }
    }
}