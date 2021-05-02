using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
  public class QuandoForExecutadoUpdate : UserTest
  {
    private IUserService _service;
    private Mock<IUserService> _serviceMock;

    [Fact(DisplayName = "É possível executar o método Update")]
    public async Task E_Possivel_Executar_Metodo_Update()
    {
      _serviceMock = new Mock<IUserService>();
      _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
      _service = _serviceMock.Object;

      var result = await _service.Post(userDtoCreate);
      Assert.NotNull(result);
      Assert.Equal(NomeUser, result.Name);
      Assert.Equal(EmailUser, result.Email);


      _serviceMock = new Mock<IUserService>();
      _serviceMock.Setup(m => m.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
      _service = _serviceMock.Object;

      var _resultUpdate = await _service.Put(userDtoUpdate);
      Assert.NotNull(_resultUpdate);
      Assert.Equal(NomeUserUpdate, _resultUpdate.Name);
      Assert.Equal(EmailUserUpdate, _resultUpdate.Email);
    }
  }
}
