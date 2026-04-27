// Program.cs
using LibraryManagement.Repositories;
using LibraryManagement.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Register IBookRepository as Scoped (new instance per HTTP request)
builder.Services.AddScoped<IBookRepository, BookRepository>();

// Register IOperationLogService as Singleton (shared across all requests)
builder.Services.AddSingleton<IOperationLogService, OperationLogService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Conventional Routing
// /Books/Index       → BooksController.Index()
// /Books/Details/1   → BooksController.Details(1)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();