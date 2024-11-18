using School.Core.Common;
using School.Core.Entities;
using System;

namespace School.Core.Entities
{
    public class Exam : BaseEntity, IAuditedEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Num { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public int RoomId  { get; set; }
        public virtual Room Room { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string? UpdatedBy { get; set; } = string.Empty;

        public DateTime? UpdatedOn { get; set; }
    }
}

