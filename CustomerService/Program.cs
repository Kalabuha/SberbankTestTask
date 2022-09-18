using SberbankDbContext.Extensions;
using DbRepositories.Extensions;
using DataServices.Extensions;
using ReadFilesService.Extensions;
using SberbankDbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DataBase");

if (string.IsNullOrEmpty(connectionString))
    throw new ArgumentNullException(nameof(connectionString));

builder.Services.RegisterDbContext(connectionString);
builder.Services.RegisterDbRepositories();
builder.Services.RegisterDataServices();
builder.Services.RegisterReadExelFilesService();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    SberbankDbContext—onnector context = scope.ServiceProvider.GetRequiredService<SberbankDbContext—onnector>();
    context.Initialize();
}

app.Run();
