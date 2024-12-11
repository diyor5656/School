using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.ModelsByS.Group;
using School.Application.Services.ServicesByS;

namespace School.API.Controllers.ControllerByS;
[ApiController]
[Route("api/[controller]")]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateGroupModel createGroupModel)
    {
        return Ok(ApiResult<CreateGroupResponseModel>.Success(
            await _groupService.CreateAsync(createGroupModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateGroupModel updateGroupModel)
    {
        return Ok(ApiResult<UpdateGroupResponseModel>.Success(
            await _groupService.UpdateAsync(id, updateGroupModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _groupService.DeleteAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var groups = await _groupService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<GroupResponseModel>>.Success((IEnumerable<GroupResponseModel>)groups));
    }
}
