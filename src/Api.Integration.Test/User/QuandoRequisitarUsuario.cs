using System.Text;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
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

      // Post
      var response = await PostJsonAsync(userDto, $"{hostApi}users", client);
      var postResult = await response.Content.ReadAsStringAsync();
      var registroPost = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);
      Assert.Equal(HttpStatusCode.Created, response.StatusCode);
      Assert.Equal(_name, registroPost.Name);
      Assert.Equal(_email, registroPost.Email);
      Assert.True(registroPost.Id != default(Guid));

      // Get All
      response = await client.GetAsync($"{hostApi}users");
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var jsonResult = await response.Content.ReadAsStringAsync();
      var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonResult);
      Assert.NotNull(listaFromJson);
      Assert.True(listaFromJson.Count() > 0);
      Assert.True(listaFromJson.Where(r => r.Id == registroPost.Id).Count() == 1);

      // Update
      var updateUserDto = new UserDtoUpdate()
      {
        Id = registroPost.Id,
        Name = Faker.Name.FullName(),
        Email = Faker.Internet.Email(),
      };

      var stringContent = new StringContent(JsonConvert.SerializeObject(updateUserDto), Encoding.UTF8, "application/json");

      response = await client.PutAsync($"{hostApi}users", stringContent);
      jsonResult = await response.Content.ReadAsStringAsync();
      var registroAtualizado = JsonConvert.DeserializeObject<UserDtoUpdateResult>(jsonResult);
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.NotEqual(registroPost.Name, registroAtualizado.Name);
      Assert.NotEqual(registroPost.Email, registroAtualizado.Email);

      // Get Id
      response = await client.GetAsync($"{hostApi}users/{registroAtualizado.Id}");
      jsonResult = await response.Content.ReadAsStringAsync();
      var registroPorId = JsonConvert.DeserializeObject<UserDto>(jsonResult);
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.Equal(registroAtualizado.Name, registroPorId.Name);
      Assert.Equal(registroAtualizado.Email, registroPorId.Email);

      // Delete
      response = await client.DeleteAsync($"{hostApi}users/{registroAtualizado.Id}");
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      response = await client.GetAsync($"{hostApi}users/{registroAtualizado.Id}");
      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
  }
}
