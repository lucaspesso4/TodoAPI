using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.Models;
using TodoAPI.Repositories.Interfaces;

namespace TodoAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoDbContext _dbContext;

        public UserRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> FindById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<UserModel> Add(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel _user = await FindById(id) ?? throw new Exception($"Cannot find User by id with id = {id}");

            _user.Id = user.Id;
            _user.Name = user.Name;
            _dbContext.Users.Update(_user);
            await _dbContext.SaveChangesAsync();

            return _user;
        }

        public async Task<bool> DeleteById(int id)
        {
            UserModel user = await FindById(id) ?? throw new Exception($"Cannot find User by id with id = {id}");

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }


    }
}
