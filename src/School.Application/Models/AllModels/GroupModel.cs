namespace School.Application.Models.ModelsByS.Group
{
    public class CreateGroupModel
    {
        public string Name { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid EmployeeId { get; set; }
    }

    public class UpdateGroupModel
    {
        public string Name { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid EmployeeId { get; set; }
    }

    public class GroupResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid EmployeeId { get; set; }
    }

    public class CreateGroupResponseModel : BaseResponseModel { }

    public class UpdateGroupResponseModel : BaseResponseModel { }
}
