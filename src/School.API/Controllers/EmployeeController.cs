using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.Employee;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;
[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateEmployeeModel createEmployeeModel)
    {
        return Ok(ApiResult<CreateEmployeeResponseModel>.Success(
            await _employeeService.CreateAsync(createEmployeeModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel)
    {
        return Ok(ApiResult<UpdateEmployeeResponseModel>.Success(
            await _employeeService.UpdateAsync(id, updateEmployeeModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _employeeService.DeleteAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var employees = await _employeeService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<EmployeeResponseModel>>.Success((IEnumerable<EmployeeResponseModel>)employees));
    }
}
