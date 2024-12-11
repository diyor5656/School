using School.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Entities
{
    public class LessonSchedule : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
        public Guid RoomId { get; set; }
        public virtual Room Room { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
