using TodoApp.Models;

namespace TodoApp.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> FindAll();
        Task<User> FindById(int id);
        Task<User> Add(User user);
        Task<User> Update(User user, int id);
        Task<bool> Delete(int id);
    }
}
