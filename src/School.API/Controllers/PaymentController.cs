using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.Payment;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;
[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreatePaymentModel createPaymentModel)
    {
        return Ok(ApiResult<CreatePaymentResponseModel>.Success(
            await _paymentService.CreateAsync(createPaymentModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdatePaymentModel updatePaymentModel)
    {
        return Ok(ApiResult<UpdatePaymentResponseModel>.Success(
            await _paymentService.UpdateAsync(id, updatePaymentModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _paymentService.DeleteAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var payments = await _paymentService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<PaymentResponseModel>>.Success((IEnumerable<PaymentResponseModel>)payments));
    }
}
