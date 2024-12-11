namespace School.Application.Models.ModelsByS.Student
{
    public class CreateStudentModel
    {
        public Guid UserId { get; set; }
    }

    public class UpdateStudentModel
    {
        public Guid UserId { get; set; }
    }

    public class StudentResponseModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }

    public class CreateStudentResponseModel : BaseResponseModel { }

    public class UpdateStudentResponseModel : BaseResponseModel { }
}
