using System.Threading.Tasks;
using Xunit;

namespace src.Api.Integration.Test
{
  public class TestLogin : BaseIntegration
  {
    [Fact(DisplayName = "test")]
    public async Task TestDoToken()
    {
      await AdicionarToken();
    }
  }
}
