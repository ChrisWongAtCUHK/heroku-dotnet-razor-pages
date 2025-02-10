- [Create a Razor Pages project](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-9.0&tabs=visual-studio-code#create-a-razor-pages-project)
- [The Edit.cshtml file](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-9.0&tabs=visual-studio-code#the-editcshtml-file)
- [Validation](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-9.0&tabs=visual-studio-code#validation)
- [CSS isolation](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-9.0&tabs=visual-studio-code#css-isolation)
- [Using Layouts, partials, templates, and Tag Helpers with Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-9.0&tabs=visual-studio-code#using-layouts-partials-templates-and-tag-helpers-with-razor-pages)
- [Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql?tab=readme-ov-file#2-services-configuration)
- [Creating RazorPage apps using the CLI](https://tattoocoder.com/creating-razorpage-apps-using-the-cli/)
- [.NET Core 中正确使用 HttpClient 的姿势](https://www.cnblogs.com/willick/p/net-core-httpclient.html)
- [ASP.Net Core Razor Pages: Convert (Export) HTML Table to Image using HTML5 Canvas](https://www.aspsnippets.com/Articles/5153/ASPNet-Core-Razor-Pages-Convert-Export-HTML-Table-to-Image-using-HTML5-Canvas/)
- [ASP.Net Core Razor Pages: Send email with attachment from a specific URL](https://www.aspsnippets.com/Articles/5045/ASPNet-Core-Razor-Pages-Send-email-with-attachment-from-a-specific-URL/)
- [Navigation menu in asp.net core razor pages project](https://csharp-video-tutorials.blogspot.com/2019/11/layout-view-in-razor-pages-project.html)
- [Query string parameters in asp.net core razor pages](https://csharp-video-tutorials.blogspot.com/2019/12/query-string-parameters-in-aspnet-core.html)
- [Route parameters in asp.net core razor pages](https://csharp-video-tutorials.blogspot.com/2019/12/route-parameters-in-aspnet-core-razor.html)
- [Creating custom route constraint in asp.net core](https://csharp-video-tutorials.blogspot.com/2019/12/aspnet-core-custom-route-constraint.html)
- [Handling 404 error in razor pages project](https://csharp-video-tutorials.blogspot.com/2019/12/handling-404-error-in-razor-pages.html)
- [Editing data in asp.net core razor pages](https://csharp-video-tutorials.blogspot.com/2019/12/editing-data-in-aspnet-core-razor-pages.html)
- [Updating data in asp.net core razor pages](https://csharp-video-tutorials.blogspot.com/2020/01/updating-data-in-aspnet-core-razor-pages.html)
- [File upload in asp.net core razor pages](https://csharp-video-tutorials.blogspot.com/2020/01/file-upload-in-aspnet-core-razor-pages.html)
- [Handle multiple forms in asp.net core razor pages](https://csharp-video-tutorials.blogspot.com/2020/01/handle-multiple-forms-in-aspnet-core.html)
- [TempData in asp.net core](https://csharp-video-tutorials.blogspot.com/2020/01/tempdata-in-aspnet-core.html)
- [ASP.NET Core razor pages validation](https://csharp-video-tutorials.blogspot.com/2020/01/aspnet-core-razor-pages-validation.html)
- [ASP.NET Core Razor Pages : CRUD Operations with Repository Pattern and Entity Framework Core](https://www.hosting.work/aspnet-core-razor-pages-repository-pattern-ef-core/)
  - [Creating Pagination for Records](https://www.hosting.work/aspnet-core-razor-pages-repository-pattern-ef-core/#pagination)
  - [Update Movie with Repository Pattern](https://www.hosting.work/aspnet-core-razor-pages-repository-pattern-ef-core/#update)
  - [Delete Movie with Repository Pattern](https://www.hosting.work/aspnet-core-razor-pages-repository-pattern-ef-core/#delete)
  - [Filtering Entity by LINQ Expression](https://www.hosting.work/aspnet-core-razor-pages-repository-pattern-ef-core/#filter-linq-expression)
- [Entity Framework Core Tutorial](https://www.csharptutorial.net/entity-framework-core-tutorial/)
  - [Getting Started with Entity Framework Core](https://www.csharptutorial.net/entity-framework-core-tutorial/getting-started-with-entity-framework-core/)
  - [How to Log SQL Queries in EF Core](https://www.csharptutorial.net/entity-framework-core-tutorial/ef-core-log-sql-query/)
  - [EF Core One-to-many Relationships](https://www.csharptutorial.net/entity-framework-core-tutorial/ef-core-one-to-many-relationship/)
- [ASP.NET Core Razor Pages Tutorial for Beginners](https://csharp-video-tutorials.blogspot.com/2020/01/aspnet-core-razor-pages-client-side.html#google_vignette)
  - [ASP.NET Core razor pages client side validation](https://csharp-video-tutorials.blogspot.com/2020/01/aspnet-core-razor-pages-client-side.html)
  - [Delete operation in asp.net core razor pages](https://csharp-video-tutorials.blogspot.com/2020/01/delete-operation-in-aspnet-core-razor.html)
  - [Partial views in asp.net core](https://csharp-video-tutorials.blogspot.com/2020/01/partial-views-in-aspnet-core.html)
  - [ASP.NET Core view components](https://csharp-video-tutorials.blogspot.com/2020/01/aspnet-core-view-components.html)
  - [ASP.NET Core view component parameter example](https://csharp-video-tutorials.blogspot.com/2020/01/pass-parameters-to-view-component-in.html)
  - [ASP.NET Core view component tag helper](https://csharp-video-tutorials.blogspot.com/2020/01/aspnet-core-view-component-tag-helper.html)
  - [Implement search page in ASP.NET Core](https://csharp-video-tutorials.blogspot.com/2020/02/implement-search-page-in-aspnet-core.html)
```
dotnet new page -n Index -na DotNetRazorPages.Pages.Area -o Pages/Area
```
```
heroku create --buildpack http://github.com/heroku/dotnet-buildpack.git
heroku buildpacks:set heroku/dotnet
```
# Playwright
```
playwright codegen --target python -o playwright/example.py "https://heroku-dotnet-razor-pages-742922653e59.herokuapp.com/"
```
```
pytest playwright/Customers/tests.py --tracing on --headed --slowmo 1000
```
```
playwright show-trace test-results/playwright-customers-tests-py-test-example-chromium/trace.zip
```