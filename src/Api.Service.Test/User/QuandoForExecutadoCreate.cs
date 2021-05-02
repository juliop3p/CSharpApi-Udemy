using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
  public class QuandoForExecutadoCreate : UserTest
  {
    private IUserService _service;
    private Mock<IUserService> _serviceMock;

    [Fact(DisplayName = "É possível executar o método Create")]
    public async Task E_Possivel_Executar_Metodo_Create()
    {
      _serviceMock = new Mock<IUserService>();
      _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
      _service = _serviceMock.Object;

      var result = await _service.Post(userDtoCreate);
      Assert.NotNull(result);
      Assert.Equal(NomeUser, result.Name);
      Assert.Equal(EmailUser, result.Email);

    }
  }
}
