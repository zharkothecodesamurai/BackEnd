using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Seavus.Recipe.Core.DataAccess;
using Seavus.Recipe.Core.Entities;
using Seavus.Recipe.Core.Services;
using Seavus.Recipe.Core.Shared;
using Seavus.Recipe.Core.Shared.Exceptions;
using Seavus.Recipe.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Seavus.Recipe.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        private IOptions<ApplicationSettings> _options;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger, IOptions<ApplicationSettings> options)
        {
            _userRepository = userRepository;
            _logger = logger;
            _options = options;

        }

        public async Task RegisterUser(RegisterVievModel registerModel)
        {

            #region Validation of registerModel

            if (string.IsNullOrEmpty(registerModel.FirstName) || registerModel.FirstName.Length > 30)
            {
                throw new UserException("FirstName must be in range of 30 characters");
            }


            if (string.IsNullOrEmpty(registerModel.LastName) || registerModel.LastName.Length > 40)
            {
                throw new UserException("LastName must be in range of 40 characters");
            }


            if (string.IsNullOrEmpty(registerModel.UserName))
            {
                throw new UserException("The username is required field");

            }


            if (registerModel.UserName.Length > 20)
            {
                throw new UserException("Username can not contain more than 20 characters!");
            }



            bool resultBool = await ValidateUniqueUsername(registerModel.UserName);


            if (!resultBool)
            {
                throw new UserException("User with this username already exists!");
            }

            bool emailBool = await ValidateEmail(registerModel.Email);
            if (!emailBool)
            {
                throw new UserException($"Please set up a valid email format");
            }


            if (string.IsNullOrEmpty(registerModel.Email) || registerModel.Email.Length > 40)
            {
                throw new UserException($"Email property should be in range of 40 charachters");
            }



            if (registerModel.Password != registerModel.ConfirmedPassword)
            {
                throw new UserException("The passwords do not match");

            }


            bool passwordBool = await ValidatePassword(registerModel.Password);
            if (!passwordBool)
            {
                throw new UserException($"Pasword is weak..Please use min 8 char and special sign");
            }

            #endregion

            MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
            //get the bytes from the entered password ---- test(string) = 1561
            byte[] passwordBytes = Encoding.ASCII.GetBytes(registerModel.Password);
            //get the bytes from the hashed password string
            byte[] md5Bytes = md5CryptoServiceProvider.ComputeHash(passwordBytes);
            //get the hashed string from the bytes ---- 1342 == t1rf (string)
            string hashedPassword = Encoding.ASCII.GetString(md5Bytes);

            User newUser = new User
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Username = registerModel.UserName,
                Email = registerModel.Email,
                Password = hashedPassword
            };

            await _userRepository.Add(newUser);


        }

        public async Task<string> LoginUser(LogingViewModel loginModel)
        {
            _logger.LogInformation($"Operation Loging in is starting");
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(loginModel.Password));
            string hashedPassword = Encoding.ASCII.GetString(md5data);

            List<User> usersDb = await _userRepository.GetAll();
            var userForLog = usersDb.FirstOrDefault(x => x.Username == loginModel.UserName
                                                                        && x.Password == hashedPassword);

            if (userForLog == null) {
                throw new NotFoundException($"The user with username {loginModel.UserName} was not found! ");
            }
                




            //authentication (identification of user) finished

            //Install System.IdentityModel.Tokens.Jwt 5.2.2 NuGet
            _logger.LogInformation($"Setting Up Token");
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            //string secretKey = "Notes app secret secret key";
            //get the SecretKey from AppSettings

            //configure the token

            byte[] secretKeyBytes = Encoding.ASCII.GetBytes(_options.Value.JWT_secret);
            //configure the token
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddSeconds(3600),
                //signature definition
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                    SecurityAlgorithms.HmacSha256Signature),
                //payload
                Subject = new ClaimsIdentity(
                    new[]
                    {
                            new Claim("UserName", userForLog.Username),
                            new Claim("UserId", userForLog.Id.ToString()),
                        //new Claim("userFullName", $"{userDb.FirstName} {userDb.LastName}"),
                    }
                )
            };
            SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string tokenReturn = jwtSecurityTokenHandler.WriteToken(token);
            return tokenReturn;
        }


        public async Task<bool> ValidatePassword(string password)
        {
            Regex passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z]).{6,20}$");
            Match passwordMatch = passwordRegex.Match(password);
            return await Task.FromResult(passwordMatch.Success);
        }

        public async Task<bool> ValidateUniqueUsername(string username)
        {
            List<User> users = await _userRepository.GetAll();

            return await Task.FromResult(users.Any(x => x.Username == username) == false);
        }

        public async Task<bool> ValidateEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return await Task.FromResult(regex.IsMatch(email));
        }

        public async Task<User> GetUserById(Guid Id)
        {
            var userDB= await _userRepository.GetUserById(Id);
            if (userDB == null)
            {
                throw new  NotFoundException ($"The user with {Id} was not found");
            }
            return userDB;
        }
    }
}
