using Microsoft.EntityFrameworkCore;
using To_Do_Management_API.Data;
using To_Do_Management_API.Entities;
using To_Do_Management_API.Interfaces;

namespace To_Do_Management_API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users
            .Include(u => u.Tasks)
            .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users
            .Include(u => u.Tasks)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> CreateAsync(User userModel)
    {
        await _context.Users.AddAsync(userModel);
        await _context.SaveChangesAsync();
        return userModel;
    }

    public async Task<User?> UpdateAsync(int id, User userModel)
    {
       var user = await _context.Users.FindAsync(id);
       if (user == null)
       {
           return null;
       }
       user.Name = userModel.Name;
       user.Email = userModel.Email;
       user.Password = userModel.Password;
       
       await _context.SaveChangesAsync();
       return user;
    }

    public async Task<User?> DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }
        
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }
}