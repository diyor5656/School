using School.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Entities
{
    public class Announcement : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
