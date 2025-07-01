using UniBazaarLite.Data;
using UniBazaarLite.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<LogActivityFilter>();
});

builder.Services.AddScoped<ValidateEntityExistsFilter>();

builder.Services.AddSingleton<IRepository, InMemoryRepository>();

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

    endpoints.MapControllers(); // MVC rotalar�n� etkinle�tir
    endpoints.MapRazorPages(); // Razor Pages rotalar�n� etkinle�tir
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"); // Varsay�lan MVC rotas�
});

app.Run();
