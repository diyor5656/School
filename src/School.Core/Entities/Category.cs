using School.Core.Common;

namespace School.Core.Entities
{
    public class Category : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

