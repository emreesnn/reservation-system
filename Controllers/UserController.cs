using Microsoft.AspNetCore.Mvc;
using RandevuYonetimSistemi.DTOs;
using RandevuYonetimSistemi.Services;

[Route("api/users/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserById(id);
        if (user == null)
            return NotFound("Kullanıcı bulunamadı.");

        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDto)
    {
        var updated = await _userService.UpdateUser(id, userDto);
        if (!updated)
            return NotFound("Güncellenecek kullanıcı bulunamadı.");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleted = await _userService.DeleteUser(id);
        if (!deleted)
            return NotFound("Silinecek kullanıcı bulunamadı.");

        return NoContent();
    }
}
