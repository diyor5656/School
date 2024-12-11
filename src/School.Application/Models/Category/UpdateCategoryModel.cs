using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Models.ModelsByS.Category
{
    public class UpdateCategoryModel
    {
        public Guid TodoListId { get; set; }

        public string Name { get; set; }

       
    }

    public class UpdateCategoryResponseModel : BaseResponseModel { }
}
