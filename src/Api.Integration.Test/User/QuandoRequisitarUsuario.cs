using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Newtonsoft.Json;
using Xunit;

namespace src.Api.Integration.Test.User
{
  public class QuandoRequisitarUsuario : BaseIntegration
  {
    public string _name { get; set; }
    public string _email { get; set; }

    [Fact(DisplayName = "É Possivel realizar o CRUD de Usuário")]
    public async Task E_Possivel_Realizar_Crud_Usuario()
    {
      await AdicionarToken();
      _name = Faker.Name.First();
      _email = Faker.Internet.Email();

      var userDto = new UserDtoCreate()
      {
        Name = _name,
        Email = _email,
      };

      var response = await PostJsonAsync(userDto, $"{hostApi}users", client);
      var postResult = await response.Content.ReadAsStringAsync();
      var registroPost = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);
      Assert.Equal(HttpStatusCode.Created, response.StatusCode);
      Assert.Equal(_name, registroPost.Name);
      Assert.Equal(_email, registroPost.Email);
      Assert.True(registroPost.Id != default(Guid));
    }
  }
}
