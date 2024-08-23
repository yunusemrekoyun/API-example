using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransferApi.Models;
using TransferApi.Services;

[ApiController]
[Route("api/[controller]")]
public class TransferController : ControllerBase
{

    private readonly ITransferService _transferService;


    public TransferController(ITransferService transferService)
    {
        _transferService = transferService;
    }


    [HttpPost("transfer")]
    public async Task<IActionResult> TransferMoney([FromBody] TransferRequest request)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }


        var result = await _transferService.TransferAsync(request);


        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result.Message);
    }
}

