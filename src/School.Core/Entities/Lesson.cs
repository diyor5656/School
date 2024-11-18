using School.Core.Common;

namespace School.Core.Entities
{
    public class Lesson : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int Number { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string? UpdatedBy { get; set; } = string.Empty;

        public DateTime? UpdatedOn { get; set; }
    }
}

