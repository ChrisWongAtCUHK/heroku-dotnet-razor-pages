using DotNetRazorPages.Constrains;
using DotNetRazorPages.Data;
using DotNetRazorPages.Entity;
using DotNetRazorPages.Models;
using DotNetRazorPages.Models.HR;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

// Write logs to logs.txt
StreamWriter _writer = new("logs.txt", true);

var builder = WebApplication.CreateBuilder(args);

var mysqlUsername = Environment.GetEnvironmentVariable("MYSQL_USERNAME");
var mysqlPassword = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
var connectionString = $"server=sql12.freesqldatabase.com;uid={mysqlUsername};pwd={mysqlPassword};database=sql12761413";
var serverVersion = new MySqlServerVersion(new Version(5, 5, 62));

builder.Services.AddTransient<IRepository<Movie>, MovieRepository<Movie>>();
// dunno why this is not work 
// builder.Services.AddTransient<IRepository<Employee>, EmployeeRepository<Employee>>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(EmployeeRepository<>));
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

builder.Services.AddDbContext<EmployeeDbContext>(
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

var app = builder.Build();

app.UseForwardedHeaders();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();

