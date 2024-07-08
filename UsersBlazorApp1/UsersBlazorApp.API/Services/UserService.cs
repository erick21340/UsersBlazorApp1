using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;
using UsersBlazorApp.API.Context;

namespace UsersBlazorApp.API.Services
{
    public class UserService : IApiService<AspNetUsers>
    {
        private readonly UsersDbContext _dbContext;

        public UserService(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AspNetUsers>> GetAllAsync()
        {
            return await _dbContext.AspNetUsers.ToListAsync();
        }

        public async Task<AspNetUsers> GetByIdAsync(int id)
        {
            return await _dbContext.AspNetUsers.FindAsync(id);
        }

        public async Task<AspNetUsers> AddAsync(AspNetUsers user)
        {
            _dbContext.AspNetUsers.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateAsync(AspNetUsers user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUsersExists(user.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _dbContext.AspNetUsers.FindAsync(id);
            if (user == null)
                return false;

            _dbContext.AspNetUsers.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private bool AspNetUsersExists(int id)
        {
            return _dbContext.AspNetUsers.Any(e => e.Id == id);
        }
    }
}
