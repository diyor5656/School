using School.Core.Common;

namespace School.Core.Entities
{
    public class Group : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public Guid TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
