using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.QuandoRequisitarGetAll
{
  public class Retorno_GetAll
  {
    private UsersController _controller;

    [Fact(DisplayName = "É Possível realizar o GetAll.")]
    public async Task E_Possivel_Invocar_A_Controller_GetAll()
    {
      var serviceMock = new Mock<IUserService>();

      List<UserDto> listaDto = new List<UserDto>();

      for (int i = 0; i < 10; i++)
      {
        var Dto = new UserDto()
        {
          Id = Guid.NewGuid(),
          Name = Faker.Name.FullName(),
          Email = Faker.Internet.Email(),
        };
        listaDto.Add(Dto);
      }

      serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaDto);

      _controller = new UsersController(serviceMock.Object);
      var result = await _controller.GetAll();
      Assert.True(result is OkObjectResult);

      var resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDto>;
      Assert.NotNull(resultValue);
      Assert.True(resultValue.Count() == 10);
    }
  }
}
