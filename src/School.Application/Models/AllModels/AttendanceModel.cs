using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace School.Application.Models.ModelsByS.Attendance
    {
        public class CreateAttendanceModel
        {
            public Guid StudentId { get; set; }
            public Guid LessonId { get; set; }
            public DateTime Date { get; set; }
            public string Status { get; set; }
        }

        public class UpdateAttendanceModel
        {
            public string Status { get; set; }
        }

        public class AttendanceResponseModel
        {
            public Guid Id { get; set; }
            public Guid StudentId { get; set; }
            public Guid LessonId { get; set; }
            public DateTime Date { get; set; }
            public string Status { get; set; }
        }

        public class CreateAttendanceResponseModel : BaseResponseModel { }

        public class UpdateAttendanceResponseModel : BaseResponseModel { }
    }

