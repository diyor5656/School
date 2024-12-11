using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.Event;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;
[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateEventModel createEventModel)
    {
        return Ok(ApiResult<CreateEventResponseModel>.Success(
            await _eventService.CreateAsync(createEventModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateEventModel updateEventModel)
    {
        return Ok(ApiResult<UpdateEventResponseModel>.Success(
            await _eventService.UpdateAsync(id, updateEventModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _eventService.DeleteAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var events = await _eventService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<EventResponseModel>>.Success((IEnumerable<EventResponseModel>)events));
    }
}
