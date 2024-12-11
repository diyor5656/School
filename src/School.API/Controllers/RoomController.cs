using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.Room;
using School.Application.Services.Impl;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;
[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomServices _roomService;

    public RoomController(IRoomServices roomService)
    {
        _roomService = roomService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateRoomModel createRoomModel)
    {
        return Ok(ApiResult<CreateRoomResponseModel>.Success(
            await _roomService.CreateAsync(createRoomModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateRoomModel updateRoomModel)
    {
        return Ok(ApiResult<UpdateRoomResponseModel>.Success(
            await _roomService.UpdateAsync(id, updateRoomModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _roomService.DeleteAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var rooms = await _roomService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<RoomResponseModel>>.Success((IEnumerable<RoomResponseModel>)rooms));
    }
}
