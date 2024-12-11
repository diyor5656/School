using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using School.Application.Exceptions;
using School.Application.Models;
using School.Application.Models.ModelsByS.Category;
using School.Application.Models.TodoItem;
using School.Application.Models.TodoList;
using School.Application.Services.ServicesByS;
using School.Core.Entities;
using School.DataAccess.Repositories;

namespace School.Application.Services.Impl;

public class CategoryService : IAllService
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMemoryCache _memoryCache;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IMemoryCache memoryCache)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _memoryCache = memoryCache;
    }

    public async Task<UpdateCategoryResponseModel> UpdateAsync(Guid id, UpdateCategoryModel updateCategoryModel, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetFirstAsync(c => c.Id == id);
        if (category == null) throw new NotFoundException($"Could not find category {id}");

        category.Name = updateCategoryModel.Name;

        var updatedCategory = await _categoryRepository.UpdateAsync(category);

        return new UpdateCategoryResponseModel
        {
            Id = updatedCategory.Id
        };
    }

    public async Task<CreateCategoryResponseModel> CreateAsync(CreatePersonModel createCategoryModel, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(createCategoryModel);

        var createdCategory = await _categoryRepository.AddAsync(category);

        return new CreateCategoryResponseModel
        {
            Id = createdCategory.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetFirstAsync(c => c.Id == id);
        if (category == null) throw new NotFoundException("Category not found");

        var deletedCategory = await _categoryRepository.DeleteAsync(category);

        return new BaseResponseModel
        {
            Id = deletedCategory.Id
        };
    }


    public async Task<CategoryResponseModel> GetByIdAsync(Guid id)
    {
        var category = await _categoryRepository.GetFirstAsync(c => c.Id == id);
        if (category == null)
            throw new NotFoundException($"Category with id {id} not found");

        return _mapper.Map<CategoryResponseModel>(category);
    }

    public async Task<IEnumerable<CategoryResponseModel>> GetAllAsync()
    {
        try
        {
            var categories = await _categoryRepository.GetAllAsync(c => true);
            var todoListResponseModels = _mapper.Map<List<CategoryResponseModel>>(categories);

            return todoListResponseModels;
        }
        catch (Exception ex)
        {
            return new List<CategoryResponseModel>();
        }
    }

   
   
}
