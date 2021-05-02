using System;
using System.Collections.Generic;
using Api.Domain.Dtos.User;

namespace Api.Service.Test
{
  public class UserTest
  {
    public static string NomeUser { get; set; }
    public string EmailUser { get; set; }
    public static string NomeUserUpdate { get; set; }
    public string EmailUserUpdate { get; set; }
    public static Guid IdUser { get; set; }
    public List<UserDto> listaDto = new List<UserDto>();
    public UserDto userDto = new UserDto();
    public UserDtoCreate userDtoCreate = new UserDtoCreate();
    public UserDtoCreateResult userDtoCreateResult = new UserDtoCreateResult();
    public UserDtoUpdate userDtoUpdate = new UserDtoUpdate();
    public UserDtoUpdateResult userDtoUpdateResult = new UserDtoUpdateResult();

    public UserTest()
    {
      IdUser = Guid.NewGuid();
      NomeUser = Faker.Name.FullName();
      EmailUser = Faker.Internet.Email();
      NomeUserUpdate = Faker.Name.FullName();
      EmailUserUpdate = Faker.Internet.Email();

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

      userDto = new UserDto
      {
        Id = IdUser,
        Name = NomeUser,
        Email = EmailUser
      };

      userDtoCreate = new UserDtoCreate
      {
        Name = NomeUser,
        Email = EmailUser,
      };

      userDtoCreateResult = new UserDtoCreateResult
      {
        Id = IdUser,
        Name = NomeUser,
        Email = EmailUser,
        CreateAt = DateTime.UtcNow
      };

      userDtoUpdate = new UserDtoUpdate
      {
        Id = IdUser,
        Name = NomeUserUpdate,
        Email = EmailUserUpdate,
      };

      userDtoUpdateResult = new UserDtoUpdateResult
      {
        Id = IdUser,
        Name = NomeUserUpdate,
        Email = EmailUserUpdate,
        UpdateAt = DateTime.UtcNow
      };
    }
  }
}
