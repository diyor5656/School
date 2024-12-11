using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.Course;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;
[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateCourseModel createCourseModel)
    {
        return Ok(ApiResult<CreateCourseResponseModel>.Success(
            await _courseService.CreateAsync(createCourseModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateCourseModel updateCourseModel)
    {
        return Ok(ApiResult<UpdateCourseResponseModel>.Success(
            await _courseService.UpdateAsync(id, updateCourseModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _courseService.DeleteAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var courses = await _courseService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<CourseResponseModel>>.Success((IEnumerable<CourseResponseModel>)courses));
    }
}
