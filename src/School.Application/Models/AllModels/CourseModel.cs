using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace School.Application.Models.ModelsByS.Course
{
    public class CreateCourseModel
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public int Duration { get; set; }
    }

    public class UpdateCourseModel
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public int Duration { get; set; }
    }

    public class CourseResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public int Duration { get; set; }
    }

    public class CreateCourseResponseModel : BaseResponseModel { }

    public class UpdateCourseResponseModel : BaseResponseModel { }
}

