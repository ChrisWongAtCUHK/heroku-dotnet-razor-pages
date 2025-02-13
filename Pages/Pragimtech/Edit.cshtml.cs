using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetRazorPages.Entity.Pragimtech;
using DotNetRazorPages.Models.Pragimtech;
using Newtonsoft.Json;

namespace DotNetRazorPages.Pages.Pragimtech;
public class EditModel(IEmployeeRepository employeeRepository,
                 IWebHostEnvironment webHostEnvironment) : PageModel
{
  private readonly IEmployeeRepository _employeeRepository = employeeRepository;
  private readonly IWebHostEnvironment webHostEnvironment = webHostEnvironment;

  [BindProperty]
  public required Employee Employee { get; set; }

  [BindProperty]
  public IFormFile? Photo { get; set; }

  [BindProperty]
  public bool Notify { get; set; }

  public required string Message { get; set; }
  public required List<Employee> Employees { get; set; } = [];

  // Make the id parameter optional
  public IActionResult OnGet(int? id)
  {
    if (TempData["Employees"] != null)
    {
      var tempData = TempData["Employees"] ?? string.Empty;
      Employees = JsonConvert.DeserializeObject<List<Employee>>((string)tempData);
    }
    // if id parameter has value, retrieve the existing
    // employee details, else create a new Employee
    if (id.HasValue)
    {
      Employee = Employees.FirstOrDefault<Employee>(e => e.Id == id.Value) ?? new Employee()
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

    TempData["Employees"] = JsonConvert.SerializeObject(Employees);
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

      if (TempData["Employees"] != null)
      {
        var tempData = TempData["Employees"] ?? string.Empty;
        Employees = JsonConvert.DeserializeObject<List<Employee>>((string)tempData);
      }
      // If Employee ID > 0, call Update() to update existing 
      // employee details else call Add() to add new employee
      if (Employee.Id > 0)
      {
        Employee = _employeeRepository.Update(Employees, Employee) ?? new Employee()
        {
          Name = string.Empty,
          Email = string.Empty
        };
      }
      else
      {
        Employee = _employeeRepository.Add(Employees, Employee);
      }
      TempData["Employees"] = JsonConvert.SerializeObject(Employees);
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
    string? photoPath = null;

    if (Photo != null)
    {
      string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");

      // for add
      if (Employee.Id == 0)
      {
        photoPath = Employee.Name + ".png";
      }
      else
      {
        // for edit
        photoPath = Employee!.PhotoPath ?? "noimage.jpg";
      }
      string filePath = Path.Combine(uploadsFolder, photoPath);
      using (var fileStream = new FileStream(filePath, FileMode.Create))
      {
        Photo.CopyTo(fileStream);
      }
    }

    return photoPath;
  }
}