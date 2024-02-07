using NLWExpertAPI.Context;
using NLWExpertAPI.Models;

namespace NLWExpertAPI.Repositories;

public class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public async Task<User?> GetUserById(int userId) =>
        await dbContext.users.FindAsync(userId);
}