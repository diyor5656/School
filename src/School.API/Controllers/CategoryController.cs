using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.Category;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IAllService _categoryService;

    public CategoryController(IAllService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreatePersonModel createCategoryModel)
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
