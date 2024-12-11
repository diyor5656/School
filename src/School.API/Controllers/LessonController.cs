using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.Lesson;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;
[ApiController]
[Route("api/[controller]")]
public class LessonController : ControllerBase
{
    private readonly ILessonService _lessonService;

    public LessonController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateLessonModel createLessonModel)
    {
        return Ok(ApiResult<CreateLessonResponseModel>.Success(
            await _lessonService.CreateAsync(createLessonModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateLessonModel updateLessonModel)
    {
        return Ok(ApiResult<UpdateLessonResponseModel>.Success(
            await _lessonService.UpdateAsync(id, updateLessonModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _lessonService.DeleteAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var lessons = await _lessonService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<LessonResponseModel>>.Success((IEnumerable<LessonResponseModel>)lessons));
    }
}
