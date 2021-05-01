using System;
using Xunit;
using AutoMapper;
using Api.CrossCutting.Mappings;

namespace Api.Service.Test
{
  public abstract class BaseTestService
  {
    public IMapper Mapper { get; set; }

    public BaseTestService()
    {
      Mapper = new AutoMapperFixture().GetMapper();
    }

    public class AutoMapperFixture : IDisposable
    {
      public IMapper GetMapper()
      {
        var config = new MapperConfiguration(cfg =>
        {
          cfg.AddProfile(new ModelToEntityProfile());
          cfg.AddProfile(new EntityToDtoProfile());
          cfg.AddProfile(new EntityToDtoProfile());
        });

        return config.CreateMapper();
      }

      public void Dispose()
      {

      }
    }
  }
}
