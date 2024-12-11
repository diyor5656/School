using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.LessonSchedule;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;
[ApiController]
[Route("api/[controller]")]
public class LessonScheduleController : ControllerBase
{
    private readonly ILessonScheduleService _lessonScheduleService;

    public LessonScheduleController(ILessonScheduleService lessonScheduleService)
    {
        _lessonScheduleService = lessonScheduleService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateLessonScheduleModel createLessonScheduleModel)
    {
        return Ok(ApiResult<CreateLessonScheduleResponseModel>.Success(
            await _lessonScheduleService.CreateAsync(createLessonScheduleModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateLessonScheduleModel updateLessonScheduleModel)
    {
        return Ok(ApiResult<UpdateLessonScheduleResponseModel>.Success(
            await _lessonScheduleService.UpdateAsync(id, updateLessonScheduleModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _lessonScheduleService.DeleteAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var lessonSchedules = await _lessonScheduleService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<LessonScheduleResponseModel>>.Success((IEnumerable<LessonScheduleResponseModel>)lessonSchedules));
    }
}
