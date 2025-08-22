using AppLoggerLibraryCS;
using AppLoggerMongoDB;
using AppLoggerPostgres;
using AppLoggerSQLServer;
using AppLoggerTextFile;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();
string logType = builder.Configuration["AppLogSettings:LogType"] ?? "TextFile";

Console.WriteLine($"LogType: {logType}");

//convert following if-else to switch-case
switch (logType.ToLower())
{
    case "sqlserver":
        builder.Services.AddSingleton<IAppLoger, AppLogSQLServerManager>();
        break;
    case "postgresql":
        builder.Services.AddSingleton<IAppLoger, AppLogPostgreSQLManager>();
        break;
    case "textfile":
        builder.Services.AddSingleton<IAppLoger, AppLogTextManager>();
        break; 
    case "mongodb":
        builder.Services.AddSingleton<IAppLoger, AppLogMongoDBManager>();
        break;
    default:
        throw new Exception("Invalid LogType specified in appsettings.json");
}

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
