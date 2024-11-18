using School.Application.Models;
using School.Application.Models.ModelsByS.Category;
using School.Application.Models.TodoItem;
using School.Application.Models.TodoList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Services.ServicesByS
{
    public interface ICategoryService
    {
        Task<CreateCategoryResponseModel> CreateAsync(CreateCategoryModel createCategoryModel,
       CancellationToken cancellationToken = default);

        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoListResponseModel>> GetAllAsync();
        Task<IEnumerable<TodoItemResponseModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<CategoryResponseModel> GetByIdAsync(Guid id);
        Task<UpdateCategoryResponseModel> UpdateAsync(Guid id, UpdateCategoryModel updateCategoryModel,
            CancellationToken cancellationToken = default);
    }
}
