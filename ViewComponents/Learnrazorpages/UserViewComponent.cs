using DotNetRazorPages.Entity.Learnrazorpages;
using Microsoft.AspNetCore.Mvc;

namespace DotNetRazorPages.ViewComponents.Learnrazorpages;

public class UserViewComponent(IUserService userService) : ViewComponent
{
  private readonly IUserService _userService = userService;

  public async Task<IViewComponentResult> InvokeAsync(int id)
  {
    var user = await _userService.GetUserAsync(id);
    return View(user);
  }
}
