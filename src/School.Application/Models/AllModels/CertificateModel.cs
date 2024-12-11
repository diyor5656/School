using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Models.ModelsByS.Certificate
{
    public class CreateCertificateModel
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime IssuedDate { get; set; }
    }

    public class UpdateCertificateModel
    {
        public DateTime IssuedDate { get; set; }
        public Guid StudentId { get; internal set; }
        public Guid CourseId { get; internal set; }
    }

    public class CertificateResponseModel
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime IssuedDate { get; set; }
    }

    public class CreateCertificateResponseModel : BaseResponseModel { }

    public class UpdateCertificateResponseModel : BaseResponseModel { }
}
