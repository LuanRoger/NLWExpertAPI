using NLWExpertAPI.Models;

namespace NLWExpertAPI.Repositories;

public interface IUserRepository
{
    public Task<User?> GetUserById(int userId);
}