using UniBazaarLite.Data;
using UniBazaarLite.Filters;
using UniBazaarLite.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<LogActivityFilter>();
});


builder.Services.AddScoped<ValidateEntityExistsFilter>();

builder.Services.AddSingleton<IRepository, InMemoryRepository>();

builder.Services.AddSingleton<CurrentUser>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();
//app.MapControllers();

app.UseEndpoints(endpoints =>
{

    endpoints.MapControllers(); // MVC rotalarýný etkinleþtir
    endpoints.MapRazorPages(); // Razor Pages rotalarýný etkinleþtir
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"); // Varsayýlan MVC rotasý
});

app.Run();
