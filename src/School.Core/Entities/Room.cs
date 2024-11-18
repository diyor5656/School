
using School.Core.Common;

namespace School.Core.Entities
{
    public class Room : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Num { get; set; }
        public int Count { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string? UpdatedBy { get; set; } = string.Empty;

        public DateTime? UpdatedOn { get; set; }
    }
}

