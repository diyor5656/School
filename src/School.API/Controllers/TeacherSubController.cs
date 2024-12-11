using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.TeacherSub;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;
[ApiController]
[Route("api/[controller]")]
public class TeacherSubController : ControllerBase
{
    private readonly ITeacherSubService _teacherSubService;

    public TeacherSubController(ITeacherSubService teacherSubService)
    {
        _teacherSubService = teacherSubService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateTeacherSubModel createTeacherSubModel)
    {
        return Ok(ApiResult<CreateTeacherSubResponseModel>.Success(
            await _teacherSubService.CreateAsync(createTeacherSubModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateTeacherSubModel updateTeacherSubModel)
    {
        return Ok(ApiResult<UpdateTeacherSubResponseModel>.Success(
            await _teacherSubService.UpdateAsync(id, updateTeacherSubModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _teacherSubService.DeleteAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var teacherSubs = await _teacherSubService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<TeacherSubResponseModel>>.Success((IEnumerable<TeacherSubResponseModel>)teacherSubs));
    }
}
