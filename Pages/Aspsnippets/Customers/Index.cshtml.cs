using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DotNetRazorPages.Models.Aspsnippets;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace DotNetRazorPages.Pages.Aspsnippets.Customers;

public class IndexModel(IWebHostEnvironment environment, IConfiguration configuration) : PageModel
{
    private readonly IWebHostEnvironment _environment = environment;
    private readonly IConfiguration _configuration = configuration;

    public List<Customer> Customers { get; set; } = [];
    public  string? FilePath { get; set; }

    public void OnGet()
    {
    }

    public void OnPostSubmit(IFormFile postedFile)
    {
        this.Customers = [];
        if (postedFile != null)
        {
            //Create a Folder.
            string path = Path.Combine(_environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Save the uploaded Excel file.
            string fileName = Path.GetFileName(postedFile.FileName);
            FilePath = Path.Combine(path, fileName);
            
            string extension = Path.GetExtension(postedFile.FileName);
            using (FileStream stream = new (FilePath, FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }

            using var doc = SpreadsheetDocument.Open(FilePath, false);
            var workbookPart = doc.WorkbookPart;
            var sheet = workbookPart!.Workbook.Sheets!.GetFirstChild<Sheet>();
            var worksheet = ((WorksheetPart)workbookPart.GetPartById(sheet!.Id!)).Worksheet;
            var worksheetName = sheet.Name;
            var sheetData = worksheet.GetFirstChild<SheetData>();
            var sharedTable = workbookPart.SharedStringTablePart!.SharedStringTable;
            // 使用物件來承接資料


            // 跳過欄位名稱的 row1
            foreach (var row in sheetData!.ChildElements.Select(x => x as Row).Skip(1))
            {
                var customer = new Customer();

                for (var i = 0; i < row!.ChildElements.Count; i++)
                {
                    var cell = row.ChildElements[i] as Cell;
                    // 取得欄位資料
                    var innerText = cell!.InnerText;
                    // 只有字串的資料會在 SharedString Table
                    if (cell.DataType != null && cell.DataType == CellValues.SharedString)
                    {
                        SharedStringItem item = sharedTable.Elements<SharedStringItem>().ElementAt(Int32.Parse(innerText));
                        innerText = item.InnerText;
                    }
                    switch (i)
                    {
                        case 0:
                            customer.CustomerId = Convert.ToInt32(innerText);
                            break;
                        case 1:
                            customer.Name = innerText;
                            break;
                        case 2:
                            customer.Country = innerText;
                            break;
                        default: break;
                    }
                }

                Customers.Add(customer);
            }
        }
    }
}
