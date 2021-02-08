using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Seavus.Recipe.Api.DataAccess.Ef.DbContext;
using Seavus.Recipe.Core.DataAccess;
using Seavus.Recipe.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seavus.Recipe.Api.DataAccess.Ef.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RecipeDbContext _recipeDbContext;
        private readonly ILogger _logger;

        public UserRepository(RecipeDbContext recipeDbContext, ILogger<UserRepository> logger)
        {
           _recipeDbContext = recipeDbContext;
            _logger = logger;
        }

        public async Task Add(User entity)
        {
            try
            {
                await _recipeDbContext.Users.AddAsync(entity);
                await _recipeDbContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"{e.InnerException}");
            }
           
            //return await Task.FromResult(savedChanges);
        }

        public async Task<List<User>> GetAll()
        {
            return await _recipeDbContext.Users.ToListAsync();          
        }
           
        

        public async Task<User> GetUserById(Guid Id)
        {
           return await _recipeDbContext.Users.FirstOrDefaultAsync(x => x.Id == Id);      
        }
    }
}
