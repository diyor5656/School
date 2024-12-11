using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Models.ModelsByS.Lesson
{
    public class CreateLessonModel
    {
        public string Name { get; set; }
        public Guid GroupId { get; set; }
        public Guid TeacherId { get; set; }
    }

    public class UpdateLessonModel
    {
        public string Name { get; set; }
        public Guid GroupId { get; set; }
        public Guid TeacherId { get; set; }
    }

    public class LessonResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid GroupId { get; set; }
        public Guid TeacherId { get; set; }
    }

    public class CreateLessonResponseModel : BaseResponseModel { }

    public class UpdateLessonResponseModel : BaseResponseModel { }
}
