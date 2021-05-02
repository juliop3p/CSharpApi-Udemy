using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
  public class QuandoForExecutadoDelete : UserTest
  {
    private IUserService _service;
    private Mock<IUserService> _serviceMock;

    [Fact(DisplayName = "É possível executar o método Delete")]
    public async Task E_Possivel_Executar_Metodo_Delete()
    {
      _serviceMock = new Mock<IUserService>();
      _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
      _service = _serviceMock.Object;

      var deletado = await _service.Delete(IdUser);
      Assert.True(deletado);

      _serviceMock = new Mock<IUserService>();
      _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
      _service = _serviceMock.Object;

      deletado = await _service.Delete(IdUser);
      Assert.False(deletado);
    }
  }
}
