using School.Core.Common;
using School.Core.Entities;

namespace School.Core.Entities
{
    public class Category : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }    
       

        //public virtual ICollection<Product> Books { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string? UpdatedBy { get; set; } = string.Empty;

        public DateTime? UpdatedOn { get; set; }
    }
}

