using School.Core.Enums;

namespace School.Application.Models.ModelsByS.Employee
{
    public class CreateEmployeeModel
    {
        public Guid PersonId { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
    }

    public class UpdateEmployeeModel
    {
        public EmployeeStatus EmployeeStatus { get; set; }
    }

    public class EmployeeResponseModel
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public string PersonName { get; set; }
        public string PersonEmail { get; set; }
    }

    public class CreateEmployeeResponseModel : BaseResponseModel { }
   

    public class UpdateEmployeeResponseModel : BaseResponseModel { }
  

    public enum Status
    {
        Admin,
        Teacher,
        Employee
    }
}
