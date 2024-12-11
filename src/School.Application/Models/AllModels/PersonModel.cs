using School.Core.Enums;

namespace School.Application.Models.ModelsByS.Person
{
    public class CreatePersonModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
    }

    public class UpdatePersonModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
    }

    public class PersonResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int Age { get; set; }
    }

    public class CreatePersonResponseModel : BaseResponseModel { }
   

    public class UpdatePersonResponseModel : BaseResponseModel { }
  
}
