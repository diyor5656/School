using School.Core.Common;
using School.Core.Enums;

namespace School.Core.Entities
{
    public class Employee : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public EmployeeStatus Status { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
