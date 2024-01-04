using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;
using TodoApp.Repository.Interfaces;

namespace TodoApp.Repository
{
    public class UserRepository : IUserRepository
    {   
        private readonly TodosDbContext _dbContext;
        public UserRepository(TodosDbContext todosDbContext) 
        {
            _dbContext = todosDbContext;
        }
        public async Task<List<User>> FindAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> FindById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<User> Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
            
            _dbContext.SaveChanges();
            
            return user;
        }

        public async Task<User> Update(User user, int id)
        {
            User updatedUser = await FindById(id);

            if (updatedUser == null) throw new Exception($"Usuário para o ID: {id} não foi encontrado.");

            updatedUser.Name = user.Name;
            updatedUser.Email = user.Email;

            _dbContext.Users.Update(updatedUser);

            await _dbContext.SaveChangesAsync();

            return updatedUser;
        }
        
        public async Task<bool> Delete(int id)
        {
            User user = await FindById(id);
            
            if (user == null) throw new Exception($"Usuário para o ID: {id} não foi encontrado.");

            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync();

            return true;
        }
                
    }
}
