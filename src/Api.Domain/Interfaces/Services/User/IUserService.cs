using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
         Task<IEnumerable<UserEntity>> GetAll();
         Task<UserEntity> Get(Guid id);
         Task<UserEntity> Post(UserEntity user);
         Task<UserEntity> Put(UserEntity user);
         Task<bool> Delete(Guid id);
    }
}
