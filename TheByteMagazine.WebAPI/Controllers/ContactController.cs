using Microsoft.AspNetCore.Mvc;
using TheByteMagazine.Application.DTOs;
using TheByteMagazine.Application.Abstractions;
using TheByteMagazine.WebAPI.Common;
using Microsoft.AspNetCore.Authorization;

namespace TheByteMagazine.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController(IMessagesService _messagesService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MessageDTO message)
    {
        try
        {
            var affectedRows = await _messagesService.CreateAsync(message);

            if (affectedRows == 0 || affectedRows == -1)
                return BadRequest(ApiResponse.Failure($"Message Creation Failed"));

            return Ok(ApiResult<int>.Success(affectedRows, "Message sent successfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }


    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var data = await _messagesService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<MessageDTO>>.Success(data));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }
}
