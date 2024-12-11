
using School.Core.Common;

namespace School.Core.Entities
{
    public class Exam : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public Guid RoomId { get; set; }
        public virtual Room Room { get; set; }
        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public DateTime ExamDate { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

