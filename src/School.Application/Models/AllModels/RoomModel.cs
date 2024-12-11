namespace School.Application.Models.ModelsByS.Room
{
    public class CreateRoomModel
    {
        public string Name { get; set; }
        public int Num { get; set; }
    }

    public class UpdateRoomModel
    {
        public string Name { get; set; }
        public int Num { get; set; }
    }

    public class RoomResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Num { get; set; }
    }

    public class CreateRoomResponseModel : BaseResponseModel { }

    public class UpdateRoomResponseModel : BaseResponseModel { }
}
