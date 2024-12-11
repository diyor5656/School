using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Models.ModelsByS.LessonSchedule
{
    public class CreateLessonScheduleModel
    {
        public Guid LessonId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class UpdateLessonScheduleModel
    {
        public Guid RoomId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class LessonScheduleResponseModel
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class CreateLessonScheduleResponseModel : BaseResponseModel { }

    public class UpdateLessonScheduleResponseModel : BaseResponseModel { }
}
