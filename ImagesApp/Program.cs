using ImagesApp.Helpers;
using ImagesTask.Core;
using ImagesTask.Core.Helpers;
using ImagesTask.Infrastructure;
using Microsoft.Extensions.Azure;
var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
builder.Services.AddControllersWithViews();

InfrastructionDependencyInjection.AddInfrastructureServices(builder.Services, configuration);
CoreDependencyInjection.AddCoreServices(builder.Services, configuration);
builder.Services.AddAutoMapper(typeof(VMtoDTOProfile));
builder.Services.AddAutoMapper(typeof(DTOtoEntityProfile));
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Image/Error");
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Images}/{action=Index}/{id?}");

app.Run();
