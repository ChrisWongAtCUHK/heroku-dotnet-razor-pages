using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetRazorPages.Entity.Pragimtech;
using DotNetRazorPages.Models.Pragimtech;

namespace DotNetRazorPages.Pages.Pragimtech;
public class EditModel(IEmployeeRepository employeeRepository,
                 IWebHostEnvironment webHostEnvironment) : PageModel
{
#pragma warning disable CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
#pragma warning restore CS9124 // Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.
    private readonly IWebHostEnvironment webHostEnvironment = webHostEnvironment;

  [BindProperty]
  public required Employee Employee { get; set; }

  [BindProperty]
  public required IFormFile Photo { get; set; }

  [BindProperty]
  public bool Notify { get; set; }

  public required string Message { get; set; }

  // Make the id parameter optional
  public IActionResult OnGet(int? id)
  {
    // if id parameter has value, retrieve the existing
    // employee details, else create a new Employee
    if (id.HasValue)
    {
      Employee = employeeRepository.GetEmployee(id.Value) ?? new Employee()
      {
        Name = string.Empty,
        Email = string.Empty
      };
    }
    else
    {
      Employee = new Employee()
      {
        Name = string.Empty,
        Email = string.Empty,
        PhotoPath = string.Empty
      };
    }

    if (Employee == null)
    {
      return RedirectToPage("/NotFound");
    }

    return Page();
  }

  public IActionResult OnPost()
  {
    if (ModelState.IsValid)
    {
      if (Photo != null)
      {
        if (Employee.PhotoPath != null)
        {
          string filePath = Path.Combine(webHostEnvironment.WebRootPath,
              "images", Employee.PhotoPath);
          System.IO.File.Delete(filePath);
        }

        Employee.PhotoPath = ProcessUploadedFile() ?? string.Empty;
      }

      // If Employee ID > 0, call Update() to update existing 
      // employee details else call Add() to add new employee
      if (Employee.Id > 0)
      {

        Employee = _employeeRepository.Update(Employee) ?? new Employee()
        {
          Name = string.Empty,
          Email = string.Empty
        };
      }
      else
      {
        Employee = _employeeRepository.Add(Employee);
      }
      return RedirectToPage("Index");
    }

    return Page();
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

    TempData["message"] = Message;

    return RedirectToPage("Details", new { id = id });
  }

  private string? ProcessUploadedFile()
  {
    string? uniqueFileName = null;

    if (Photo != null)
    {
      string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
      uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
      string filePath = Path.Combine(uploadsFolder, uniqueFileName);
      using (var fileStream = new FileStream(filePath, FileMode.Create))
      {
        Photo.CopyTo(fileStream);
      }
    }

    return uniqueFileName;
  }
}