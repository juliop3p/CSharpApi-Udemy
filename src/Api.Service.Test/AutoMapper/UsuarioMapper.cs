using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
  public class UsuarioMapper : BaseTestService
  {
    [Fact(DisplayName = "É possível mapper os modelos")]
    public void E_Possivel_Mapear_Os_Modelos()
    {
      var model = new UserModel
      {
        Id = Guid.NewGuid(),
        Name = Faker.Name.FullName(),
        Email = Faker.Internet.Email(),
        CreateAt = DateTime.UtcNow,
        UpdateAt = DateTime.UtcNow,
      };

      var listEntity = new List<UserEntity>();

      for (int i = 0; i < 5; i++)
      {
        var item = new UserEntity
        {
          Id = Guid.NewGuid(),
          Name = Faker.Name.FullName(),
          Email = Faker.Internet.Email(),
          CreateAt = DateTime.UtcNow,
          UpdateAt = DateTime.UtcNow,
        };

        listEntity.Add(item);
      }

      // Model => Entity
      var entity = Mapper.Map<UserEntity>(model);
      Assert.Equal(entity.Id, model.Id);
      Assert.Equal(entity.Name, model.Name);
      Assert.Equal(entity.Email, model.Email);
      Assert.Equal(entity.CreateAt, model.CreateAt);
      Assert.Equal(entity.UpdateAt, model.UpdateAt);

      // Entity => Dto
      var userDto = Mapper.Map<UserDto>(entity);
      Assert.Equal(userDto.Id, entity.Id);
      Assert.Equal(userDto.Name, entity.Name);
      Assert.Equal(userDto.Email, entity.Email);
      Assert.Equal(userDto.CreateAt, entity.CreateAt);

      // LIST - Entity => Dto
      var listDto = Mapper.Map<List<UserDto>>(listEntity);
      Assert.True(listDto.Count() == listEntity.Count());
      for (int i = 0; i < 5; i++)
      {
        Assert.Equal(listDto[i].Id, listEntity[i].Id);
        Assert.Equal(listDto[i].Name, listEntity[i].Name);
        Assert.Equal(listDto[i].Email, listEntity[i].Email);
        Assert.Equal(listDto[i].CreateAt, listEntity[i].CreateAt);
      }

      // Entity => DtoCreate
      var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(entity);
      Assert.Equal(userDtoCreateResult.Id, entity.Id);
      Assert.Equal(userDtoCreateResult.Name, entity.Name);
      Assert.Equal(userDtoCreateResult.Email, entity.Email);
      Assert.Equal(userDtoCreateResult.CreateAt, entity.CreateAt);

      // Entity => DtoUpdate
      var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(entity);
      Assert.Equal(userDtoUpdateResult.Id, entity.Id);
      Assert.Equal(userDtoUpdateResult.Name, entity.Name);
      Assert.Equal(userDtoUpdateResult.Email, entity.Email);
      Assert.Equal(userDtoUpdateResult.UpdateAt, entity.UpdateAt);
    }
  }
}
