using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransferApi.Models;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] User newUser)
    {
        if (newUser == null)
        {
            return BadRequest("User data is null.");
        }

        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            Message = "User successfully added.",
            User = newUser
        });
    }
}