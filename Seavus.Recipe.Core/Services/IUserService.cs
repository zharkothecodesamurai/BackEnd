
using Seavus.Recipe.Core.Entities;
using Seavus.Recipe.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seavus.Recipe.Core.Services
{
    public interface IUserService
    {
        Task RegisterUser(RegisterVievModel registerModel);
        Task<string> LoginUser(LogingViewModel loginModel);
        Task<bool> ValidateUniqueUsername(string username);
        Task<bool> ValidatePassword(string password);
        Task<bool> ValidateEmail(string email);

        Task<User> GetUserById(Guid Id);
    }
}
