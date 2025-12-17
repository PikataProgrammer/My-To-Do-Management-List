using Microsoft.EntityFrameworkCore;
using To_Do_Management_API.Entities;

namespace To_Do_Management_API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
    {
    }
    public DbSet<User> Users => Set<User>();
    public DbSet<TodoTask> TodoTasks => Set<TodoTask>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "Pepi Dermendjiev",
                Email = "pepi@gmail.com",
                Password = "123456789",
            });
    }
}