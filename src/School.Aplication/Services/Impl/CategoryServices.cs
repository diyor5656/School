using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using School.Application.Exceptions;
using School.Application.Models;
using School.Application.Models.ModelsByS.Category;
using School.Application.Models.TodoItem;
using School.Application.Models.TodoList;
using School.Application.Services.ServicesByS;
using School.Core;
using School.Core.Entities;

namespace School.Application.Services.Impl;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly Access.Repositories.ICategoryRepository _categoryRepository;
    private readonly IMemoryCache _memoryCache;

    public CategoryService(Access.Repositories.ICategoryRepository categoryRepository, IMapper mapper, IMemoryCache memoryCache)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _memoryCache = memoryCache;
    }

    public async Task<UpdateCategoryResponseModel> UpdateAsync(Guid id, UpdateCategoryModel updateCategoryModel, CancellationToken cancellationToken)
    {
        var category =await _categoryRepository.GetFirstAsync(c => c.Id == id);
        if (category == null) throw new NotFoundException($"Could not find category {id}");

        category.Name = updateCategoryModel.Name;
        
        

        return new UpdateCategoryResponseModel
        {
            Id = (await _categoryRepository.UpdateAsync(category)).Id
        };

        throw new NotImplementedException();
    }

    public async Task<CreateCategoryResponseModel> CreateAsync(CreateCategoryModel createCategoryModel, CancellationToken cancellationToken)
    {
        //var category = _mapper.Map<Category>(createCategoryModel);

        var category = new Category
        {
            Name = createCategoryModel.Name,
        };
        
        return new CreateCategoryResponseModel
        {
            Id = (await _categoryRepository.AddAsync(category)).Id
        };
        throw new NotImplementedException();
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetFirstAsync(c => c.Id == id);
        if(category == null) throw new NotFoundException("Category not found");

        return new BaseResponseModel
        {
            Id = (await _categoryRepository.DeleteAsync(category)).Id
        };

        throw new NotImplementedException();
    }

   
    //public async Task<IEnumerable<TodoListResponseModel>> GetAllAsync()
    //{
    //    var categories = await _categoryRepository.GetAllAsync();

    //    return _mapper.Map<IEnumerable<TodoListResponseModel>>(categories);
    //}

    public Task<CategoryResponseModel> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TodoItemResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<TodoListResponseModel>> ICategoryService.GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
