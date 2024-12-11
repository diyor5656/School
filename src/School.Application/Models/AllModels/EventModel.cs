using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace School.Application.Models.ModelsByS.Event
{
    public class CreateEventModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
    }

    public class UpdateEventModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
    }

    public class EventResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
    }

    public class CreateEventResponseModel : BaseResponseModel { }

    public class UpdateEventResponseModel : BaseResponseModel { }
}
