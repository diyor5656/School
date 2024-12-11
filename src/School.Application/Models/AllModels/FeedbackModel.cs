using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace School.Application.Models.ModelsByS.Feedback
{
    public class CreateFeedbackModel
    {
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
    }

    public class UpdateFeedbackModel
    {
        public string Comments { get; set; }
        public int Rating { get; set; }
    }

    public class FeedbackResponseModel
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
    }

    public class CreateFeedbackResponseModel : BaseResponseModel { }

    public class UpdateFeedbackResponseModel : BaseResponseModel { }
}
