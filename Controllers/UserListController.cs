using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransferApi.Repositories;

[ApiController]
[Route("api/[controller]")]
public class UserListController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UserListController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return Ok(users);
    }
}

