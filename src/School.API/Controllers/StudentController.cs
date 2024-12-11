using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.Student;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateStudentModel createStudentModel)
    {
        return Ok(ApiResult<CreateStudentResponseModel>.Success(
            await _studentService.CreateAsync(createStudentModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateStudentModel updateStudentModel)
    {
        return Ok(ApiResult<UpdateStudentResponseModel>.Success(
            await _studentService.UpdateAsync(id, updateStudentModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _studentService.DeleteAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var students = await _studentService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<StudentResponseModel>>.Success((IEnumerable<StudentResponseModel>)students));
    }
}
