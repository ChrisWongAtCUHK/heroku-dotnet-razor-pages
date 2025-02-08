using DotNetRazorPages.Models;
using DotNetRazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetRazorPages.Pages.Employees;

public class EditModel(ILogger<EditModel> logger, IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment) : PageModel
{
  private readonly ILogger<EditModel> _logger = logger;

#pragma warning disable CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.
  private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
  private readonly IEmployeeRepository _employeeRepository = employeeRepository;
#pragma warning restore CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.


  [BindProperty]
  public required Employee Employee { get; set; }

  // We use this property to store and process
  // the newly uploaded photo
  public IFormFile? Photo { get; set; }

  [BindProperty]
  public bool Notify { get; set; }

  public string? Message { get; set; }
  public IActionResult OnGet(int id)
  {
    Employee = _employeeRepository.GetEmployee(id);
    if (Employee == null)
    {
      return RedirectToPage("/NotFound");
    }

    return Page();
  }

  public IActionResult OnPost(Employee employee)
  {
    if (Photo != null)
    {
      // If a new photo is uploaded, the existing photo must be
      // deleted. So check if there is an existing photo and delete
      if (employee.PhotoPath != null)
      {
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath,
            "images", employee.PhotoPath);
        System.IO.File.Delete(filePath);
      }
      // Save the new photo in wwwroot/images folder and update
      // PhotoPath property of the employee object
      ProcessUploadedFile();
    }

    Employee = _employeeRepository.Update(employee);
    return RedirectToPage("Index");
  }

  public IActionResult OnPostUpdateNotificationPreferences(int id)
  {
    if (Notify)
    {
      Message = "Thank you for turning on notifications";
    }
    else
    {
      Message = "You have turned off email notifications";
    }

    // Store the confirmation message in TempData
    TempData["message"] = Message;

    // Redirect the request to Details razor page and pass along 
    // EmployeeID in URL as a route parameter
    return RedirectToPage("Details", new { id = id });
  }


  private void ProcessUploadedFile()
  {
    if (Photo != null)
    {
      string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
      string filePath = Path.Combine(uploadFolder, Employee.PhotoPath ?? "noimage.jpg");
      using (var fileStream = new FileStream(filePath, FileMode.Create))
      {
        Photo.CopyTo(fileStream);
      }
    }
  }
}
