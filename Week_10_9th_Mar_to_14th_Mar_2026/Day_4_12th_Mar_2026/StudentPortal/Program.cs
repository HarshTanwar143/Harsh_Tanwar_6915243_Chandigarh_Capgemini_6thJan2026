// Program.cs
using StudentPortal.Services;
using StudentPortal.Middleware;

var builder = WebApplication.CreateBuilder(args);

// ── 1. Register services in DI container ──────────────────────────
builder.Services.AddControllersWithViews();

// Register IRequestLoggingService as Singleton
// Singleton = one shared instance for entire app lifetime
builder.Services.AddSingleton<IRequestLoggingService, RequestLoggingService>();

var app = builder.Build();

// ── 2. Configure HTTP pipeline (ORDER MATTERS) ────────────────────
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();      // serves CSS/JS from wwwroot/
app.UseRouting();          // enables routing

// ← Register our custom middleware AFTER UseRouting
app.UseMiddleware<RequestTrackingMiddleware>();

app.UseAuthorization();

// ── 3. Configure Conventional Routing ────────────────────────────
// Pattern: {controller}/{action}/{id?}
// /Students/Index → StudentsController.Index()
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();
