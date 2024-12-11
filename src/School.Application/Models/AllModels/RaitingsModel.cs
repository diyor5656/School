namespace School.Application.Models.ModelsByS.Raiting
{
    public class CreateRaitingModel
    {
        public Guid StudentId { get; set; }
        public int Score { get; set; }
    }

    public class UpdateRaitingModel
    {
        public int Score { get; set; }
    }

    public class RaitingResponseModel
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public int Score { get; set; }
    }

    public class CreateRaitingResponseModel : BaseResponseModel { }

    public class UpdateRaitingResponseModel : BaseResponseModel { }
}
