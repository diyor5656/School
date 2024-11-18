using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.Category;
using School.Application.Services;
using School.Application.Services.ServicesByS;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.API.Controllers.ControllerByS
{
  
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateCategoryModel createCategoryModel)
        {
            return Ok(ApiResult<CreateCategoryResponseModel>.Success(
                await _categoryService.CreateAsync(createCategoryModel)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateCategoryModel updateCategoryModel)
        {
            return Ok(ApiResult<UpdateCategoryResponseModel>.Success(
                await _categoryService.UpdateAsync(id, updateCategoryModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponseModel>.Success(await _categoryService.DeleteAsync(id)));
        }   

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<CategoryResponseModel>>.Success((IEnumerable<CategoryResponseModel>)categories));
        }
    }
}
