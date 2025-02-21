using DotNetRazorPages.Constraints;
using DotNetRazorPages.Data;
using DotNetRazorPages.Data.HR;
using DotNetRazorPages.Entity;
using DotNetRazorPages.Entity.HR;
using DotNetRazorPages.Entity.Learnrazorpages;
using DotNetRazorPages.Entity.Pragimtech;
using DotNetRazorPages.Models;
using DotNetRazorPages.Models.HR;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

// Write logs to logs.txt
StreamWriter _writer = new("logs.txt", true);

var builder = WebApplication.CreateBuilder(args);

var mysqlUsername = Environment.GetEnvironmentVariable("MYSQL_USERNAME");
var mysqlPassword = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
var connectionString = $"server=sql12.freesqldatabase.com;uid={mysqlUsername};pwd={mysqlPassword};database=sql12761413";
var serverVersion = new MySqlServerVersion(new Version(5, 5, 62));

builder.Services.AddTransient<IRepository<Movie>, MovieRepository<Movie>>(); 
builder.Services.AddTransient<IRepository<MySqlEmployee>, EmployeeRepository<MySqlEmployee>>();
builder.Services.AddTransient<IRepository<Department>, DepartmentRepository<Department>>();
builder.Services.AddTransient(typeof(IEmployeeRepository), typeof(MockEmployeeRepository));
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<CustomerDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        // The following three options help with debugging, but should
        // be changed or removed for production.
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

builder.Services.AddDbContext<MovieDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        // The following three options help with debugging, but should
        // be changed or removed for production.
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

builder.Services.AddDbContext<HRDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        .LogTo(_writer.WriteLine)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging()
);

var isHeroku = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DYNO"));
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    if (isHeroku)
    {
        options.KnownNetworks.Clear();
        options.KnownProxies.Clear();
    }
});
builder.Services.AddHttpsRedirection(options =>
{
    if (isHeroku)
    {
        options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
        options.HttpsPort = 443;
    }
    ;
});

builder.Services.AddHttpClient();

builder.Services.AddRouting(options =>
    options.ConstraintMap.Add("even", typeof(EvenConstraint)));

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
var app = builder.Build();

app.UseForwardedHeaders();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
// Set up custom content types - associating file extension to MIME type
var provider = new FileExtensionContentTypeProvider();
// Add new mapping
provider.Mappings[".vue"] = "application/octet-stream";

app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

app.UseRouting();

app.MapRazorPages();

app.Run();

