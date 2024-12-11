using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Models.AllModels
{
    
        public class CreateAnnouncementModel
        {
            public string Message { get; set; }
            public Guid GroupId { get; set; }
        }

        public class UpdateAnnouncementModel
        {
            public string Message { get; set; }
            public Guid GroupId { get; set; }
        }

        public class AnnouncementResponseModel
        {
            public Guid Id { get; set; }
            public string Message { get; set; }
            public Guid GroupId { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class CreateAnnouncementResponseModel : BaseResponseModel { }

        public class UpdateAnnouncementResponseModel : BaseResponseModel { }
    

}
