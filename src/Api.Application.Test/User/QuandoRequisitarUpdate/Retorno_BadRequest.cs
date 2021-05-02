using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.QuandoRequisitarDelete
{
  public class Retorno_BadRequest
  {
    private UsersController _controller;

    [Fact(DisplayName = "É Possível realizar o BadRequest.")]
    public async Task E_Possivel_Invocar_A_Controller_Delete()
    {
      var serviceMock = new Mock<IUserService>();

      serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

      _controller = new UsersController(serviceMock.Object);
      _controller.ModelState.AddModelError("Id", "Use um Id válido!");

      var result = await _controller.Delete(default(Guid));
      Assert.True(result is BadRequestObjectResult);
    }
  }
}
