using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Models.ModelsByS.Payment
{
    public class CreatePaymentModel
    {
        public Guid StudentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; }
    }

    public class UpdatePaymentModel
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; }
    }

    public class PaymentResponseModel
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; }
    }

    public class CreatePaymentResponseModel : BaseResponseModel { }

    public class UpdatePaymentResponseModel : BaseResponseModel { }
}
