using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.Enrollment;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;
[ApiController]
[Route("api/[controller]")]
public class EnrollmentController : ControllerBase
{
    private readonly IEnrollmentService _enrollmentService;

    public EnrollmentController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateEnrollmentModel createEnrollmentModel)
    {
        return Ok(ApiResult<CreateEnrollmentResponseModel>.Success(
            await _enrollmentService.CreateAsync(createEnrollmentModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateEnrollmentModel updateEnrollmentModel)
    {
        return Ok(ApiResult<UpdateEnrollmentResponseModel>.Success(
            await _enrollmentService.UpdateAsync(id, updateEnrollmentModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _enrollmentService.DeleteAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var enrollments = await _enrollmentService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<EnrollmentResponseModel>>.Success((IEnumerable<EnrollmentResponseModel>)enrollments));
    }
}
