using School.Core.Common;

namespace School.Core.Entities
{
    public class Rating : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Score { get; set; }
        public int StudentId  { get; set; }
        public virtual Student Student { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string? UpdatedBy { get; set; } = string.Empty;

        public DateTime? UpdatedOn { get; set; }
    }
}

