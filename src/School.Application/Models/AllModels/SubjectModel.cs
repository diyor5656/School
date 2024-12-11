namespace School.Application.Models.ModelsByS.Subject
{
    public class CreateSubjectModel
    {
        public string Name { get; set; }
    }

    public class UpdateSubjectModel
    {
        public string Name { get; set; }
    }

    public class SubjectResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class CreateSubjectResponseModel : BaseResponseModel { }

    public class UpdateSubjectResponseModel : BaseResponseModel { }
}
