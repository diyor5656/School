using School.Core.Common;

namespace School.Core.Entities
{
    public class Student : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public virtual User Person { get; set; }
        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
