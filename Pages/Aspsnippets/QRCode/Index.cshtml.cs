using Microsoft.AspNetCore.Mvc.RazorPages;
using Net.Codecrete.QrCodeGenerator;
using System.Text;

namespace DotNetRazorPages.Pages.Aspsnippets.QRCode;

public class IndexModel(IWebHostEnvironment environment) : PageModel
{
    private readonly IWebHostEnvironment _environment = environment;

    public bool IsQRCodeSvgGenerate { get; set; }

    public void OnPostGenerate(string qrcode)
    {
        //Fetch file name of the Logo Image.
        string folder = Path.Combine(_environment.WebRootPath, "images");
        string fileName = Path.Combine(folder, "qrcode.svg");

        //Read the Logo Image.
        var qr = QrCode.EncodeText(qrcode, QrCode.Ecc.Medium);
        string svg = qr.ToSvgString(4);
        System.IO.File.WriteAllText(fileName, svg, Encoding.UTF8);

        IsQRCodeSvgGenerate = true;
    }
}
