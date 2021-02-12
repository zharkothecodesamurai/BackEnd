using Seavus.Recipe.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seavus.Recipe.Core.DataAccess
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetUserById(Guid Id);
        Task Add(User entity);

        Task Update(User entity);
    }
}
