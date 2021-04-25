using System.Net;
using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Dtos;

namespace Api.Application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    [HttpPost]
    public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (loginDto == null)
      {
        return BadRequest();
      }

      try
      {
        var result = await service.FindByLogin(loginDto);

        if (result != null)
        {
          return Ok(result);
        }
        else
        {
          return NotFound();
        }
      }
      catch (ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }
  }
}
