namespace NewProject.Domain.models.Refrence
{
    public class TaskType
    {
        public int TaskTypeID { get; set; }
        public int? TenantID { get; set; }
        public string TaskTypeName { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
    }
}