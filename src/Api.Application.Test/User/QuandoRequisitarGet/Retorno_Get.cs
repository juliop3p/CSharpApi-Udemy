using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.QuandoRequisitarGet
{
  public class Retorno_Get
  {
    private UsersController _controller;

    [Fact(DisplayName = "É Possível realizar o Get.")]
    public async Task E_Possivel_Invocar_A_Controller_Get()
    {
      var serviceMock = new Mock<IUserService>();
      var name = Faker.Name.FullName();
      var email = Faker.Internet.Email();

      serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
        new UserDto
        {
          Id = Guid.NewGuid(),
          Name = name,
          Email = email,
          CreateAt = DateTime.UtcNow,
        }
      );

      _controller = new UsersController(serviceMock.Object);
      var result = await _controller.GetById(Guid.NewGuid());
      Assert.True(result is OkObjectResult);

      var resultValue = ((OkObjectResult)result).Value as UserDto;
      Assert.NotNull(resultValue);
      Assert.Equal(name, resultValue.Name);
      Assert.Equal(email, resultValue.Email);
    }
  }
}
