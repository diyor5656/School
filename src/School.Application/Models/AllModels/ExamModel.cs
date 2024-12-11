namespace School.Application.Models.ModelsByS.Exam
{
    public class CreateExamModel
    {
        public Guid StudentId { get; set; }  
        public Guid RoomId { get; set; }   
        public Guid SubjectId { get; set; } 
    }

    public class UpdateExamModel
    {
        public Guid StudentId { get; set; } 
        public Guid RoomId { get; set; }   
        public Guid SubjectId { get; set; } 
    }

    public class ExamResponseModel
    {
        public Guid Id { get; set; } 
        public Guid StudentId { get; set; }  
        public Guid RoomId { get; set; }   
        public Guid SubjectId { get; set; } 
        public string RoomName { get; set; } 
        public string SubjectName { get; set; }
        public string StudentName { get; set; } 
    }

    public class CreateExamResponseModel : BaseResponseModel { }

    public class UpdateExamResponseModel : BaseResponseModel { }
}
