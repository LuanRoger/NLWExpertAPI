using NLWExpertAPI.Models;

namespace NLWExpertAPI.Repositories;

public interface IUserRepository
{
    public Task<User?> GetUserById(int userId);
    public Task<User?> GetUserByEmail(string email);
    public Task<User> CreateNewUser(User user);
    public Task FlushChanges();
}