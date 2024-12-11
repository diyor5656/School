using School.Core.Common;
using System.Threading.Tasks.Sources;

namespace School.Core.Entities
{
    public class Rating : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int Score { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
