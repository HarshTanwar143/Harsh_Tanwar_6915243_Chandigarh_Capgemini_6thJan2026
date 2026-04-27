var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("WeatherApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5282/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Weather}/{action=Index}/{id?}");

app.Run();
