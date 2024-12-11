using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Models.ModelsByS.TeacherSub
{
    public class CreateTeacherSubModel
    {
        public Guid TeacherId { get; set; }
        public Guid SubjectId { get; set; }
    }

    public class UpdateTeacherSubModel
    {
        public Guid TeacherId { get; set; }
        public Guid SubjectId { get; set; }
    }

    public class TeacherSubResponseModel
    {
        public Guid Id { get; set; }
        public Guid TeacherId { get; set; }
        public Guid SubjectId { get; set; }
    }

    public class CreateTeacherSubResponseModel : BaseResponseModel { }

    public class UpdateTeacherSubResponseModel : BaseResponseModel { }
}
