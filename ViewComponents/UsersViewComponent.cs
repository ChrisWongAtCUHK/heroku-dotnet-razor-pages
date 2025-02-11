using DotNetRazorPages.Entity.Learnrazorpages;
using Microsoft.AspNetCore.Mvc;

namespace DotNetRazorPages.ViewComponents;

public class UsersViewComponent(IUserService userService) : ViewComponent
{
  private readonly IUserService _userService = userService;

    public async Task<IViewComponentResult> InvokeAsync()
  {
    var users = await _userService.GetUsersAsync();
    return View(users);
  }
}
