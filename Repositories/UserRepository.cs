using Microsoft.EntityFrameworkCore;
using NLWExpertAPI.Context;
using NLWExpertAPI.Models;

namespace NLWExpertAPI.Repositories;

public class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public async Task<User?> GetUserById(int userId) =>
        await dbContext.users.FindAsync(userId);
    public async Task<User?> GetUserByEmail(string email) =>
        await dbContext.users.FirstOrDefaultAsync(u => u.email == email);
    public async Task<User> CreateNewUser(User user)
    {
        var newEntity = await dbContext.AddAsync(user);
        User newUser = newEntity.Entity;
        return newUser;
    }
    
    public async Task FlushChanges() =>
        await dbContext.SaveChangesAsync();
}