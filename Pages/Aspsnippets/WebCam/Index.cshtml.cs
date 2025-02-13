using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetRazorPages.Pages.Aspsnippets.WebCam;

[ValidateAntiForgeryToken]
public class IndexModel(IWebHostEnvironment environment) : PageModel
{
    private readonly IWebHostEnvironment _environment = environment;

    public void OnGet()
    {
    }

    public ActionResult OnPostSaveCapturedImage(string data)
    {
        string fileName = DateTime.Now.ToString("dd-MM-yy_hh-mm-ss");

        //Convert Base64 Encoded string to Byte Array.
        byte[] imageBytes = Convert.FromBase64String(data.Split(',')[1]);

        //Save the Byte Array as Image File.
        string filePath = Path.Combine(_environment.WebRootPath, string.Format("Captures/{0}.jpg", fileName));
        System.IO.File.WriteAllBytes(filePath, imageBytes);
        return new EmptyResult();
    }
}
