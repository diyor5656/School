using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.Certificate;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;
[ApiController]
[Route("api/[controller]")]
public class CertificateController : ControllerBase
{
    private readonly ICertificateService _certificateService;

    public CertificateController(ICertificateService certificateService)
    {
        _certificateService = certificateService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateCertificateModel createCertificateModel)
    {
        return Ok(ApiResult<CreateCertificateResponseModel>.Success(
            await _certificateService.CreateAsync(createCertificateModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateCertificateModel updateCertificateModel)
    {
        return Ok(ApiResult<UpdateCertificateResponseModel>.Success(
            await _certificateService.UpdateAsync(id, updateCertificateModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _certificateService.DeleteAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var certificates = await _certificateService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<CertificateResponseModel>>.Success((IEnumerable<CertificateResponseModel>)certificates));
    }
}
