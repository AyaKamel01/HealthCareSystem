
using HealthCareSystem.PL.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add MVC Services
builder.Services.AddControllersWithViews();

// Register Application Services
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure HTTP Request Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
