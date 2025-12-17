using To_Do_Management_API.Entities;

namespace To_Do_Management_API.Interfaces;

public interface IUserRepository
{
    public Task<List<User>> GetAllAsync();
    public Task<User?> GetByIdAsync(int id);
    public Task<User> CreateAsync(User userModel);
    public Task<User?> UpdateAsync(int id, User userModel);
    public Task<User?> DeleteAsync(int id);
}