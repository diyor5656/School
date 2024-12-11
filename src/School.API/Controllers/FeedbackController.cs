using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.Feedback;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;
[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly IFeedbackService _feedbackService;

    public FeedbackController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateFeedbackModel createFeedbackModel)
    {
        return Ok(ApiResult<CreateFeedbackResponseModel>.Success(
            await _feedbackService.CreateAsync(createFeedbackModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateFeedbackModel updateFeedbackModel)
    {
        return Ok(ApiResult<UpdateFeedbackResponseModel>.Success(
            await _feedbackService.UpdateAsync(id, updateFeedbackModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _feedbackService.DeleteAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var feedbacks = await _feedbackService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<FeedbackResponseModel>>.Success((IEnumerable<FeedbackResponseModel>)feedbacks));
    }
}
