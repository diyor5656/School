using School.Application.Models;
using School.Application.Models.ModelsByS.Category;
using School.Application.Models.TodoItem;
using School.Application.Models.TodoList;
using School.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace School.Application.Services.ServicesByS
{
    public interface IAllService
    {

        Task<CreateCategoryResponseModel> CreateAsync(CreatePersonModel createCategoryModel,
            CancellationToken cancellationToken = default);

        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<CategoryResponseModel>> GetAllAsync();


        Task<CategoryResponseModel> GetByIdAsync(Guid id);

        Task<UpdateCategoryResponseModel> UpdateAsync(Guid id, UpdateCategoryModel updateCategoryModel,
            CancellationToken cancellationToken = default);

    }
}
