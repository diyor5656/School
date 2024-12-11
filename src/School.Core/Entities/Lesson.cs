using School.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Entities
{
    public class Lesson : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
        public string Name { get; set; }
        public Guid TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
