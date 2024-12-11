using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.Attendance;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;
[ApiController]
[Route("api/[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateAttendanceModel createAttendanceModel)
    {
        return Ok(ApiResult<CreateAttendanceResponseModel>.Success(
            await _attendanceService.CreateAsync(createAttendanceModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateAttendanceModel updateAttendanceModel)
    {
        return Ok(ApiResult<UpdateAttendanceResponseModel>.Success(
            await _attendanceService.UpdateAsync(id, updateAttendanceModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _attendanceService.DeleteAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var attendances = await _attendanceService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<AttendanceResponseModel>>.Success((IEnumerable<AttendanceResponseModel>)attendances));
    }
}
