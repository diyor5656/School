using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Models.ModelsByS.Enrollment
{
    public class CreateEnrollmentModel
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }

    public class UpdateEnrollmentModel
    {
        public DateTime EnrollmentDate { get; set; }
    }

    public class EnrollmentResponseModel
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }

    public class CreateEnrollmentResponseModel : BaseResponseModel { }

    public class UpdateEnrollmentResponseModel : BaseResponseModel { }
}
