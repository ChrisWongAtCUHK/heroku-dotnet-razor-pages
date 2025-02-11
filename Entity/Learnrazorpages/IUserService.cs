using DotNetRazorPages.Models.Learnrazorpages;

namespace DotNetRazorPages.Entity.Learnrazorpages;

public interface IUserService
{
  Task<List<User>> GetUsersAsync();
  Task<User> GetUserAsync(int id);
}