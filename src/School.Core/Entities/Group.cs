using School.Core.Common;

namespace School.Core.Entities
{
    public class Group : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string? UpdatedBy { get; set; } = string.Empty;

        public DateTime? UpdatedOn { get; set; }
    }
}

