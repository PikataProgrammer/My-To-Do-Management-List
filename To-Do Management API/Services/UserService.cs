using To_Do_Management_API.Data;
using To_Do_Management_API.Entities;
using To_Do_Management_API.Interfaces;

namespace To_Do_Management_API.Services;

public class UserService : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<List<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> CreateAsync(User userModel)
    {
        throw new NotImplementedException();
    }

    public Task<User?> UpdateAsync(int id, User userModel)
    {
        throw new NotImplementedException();
    }

    public Task<User?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}