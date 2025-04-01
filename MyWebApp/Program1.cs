using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using MyWebApp.Data;
using MyWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add database service
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=users.db"));

var app = builder.Build();

app.UseStaticFiles();

// Auto-create database on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); // Ensures the database is created
}

// Handle user registration
app.MapPost("/register", async (HttpContext context, AppDbContext db) =>
{
    var request = await JsonSerializer.DeserializeAsync<User>(context.Request.Body);

    if (request != null && !string.IsNullOrWhiteSpace(request.Username) && !string.IsNullOrWhiteSpace(request.Password))
    {
        // Check if user already exists
        if (db.Users.Any(u => u.Username == request.Username))
        {
            await context.Response.WriteAsJsonAsync(new { success = false, message = "Username already exists." });
            return;
        }

        db.Users.Add(new User { Username = request.Username, Password = request.Password });
        await db.SaveChangesAsync();

        await context.Response.WriteAsJsonAsync(new { success = true, message = "User registered successfully!" });
    }
    else
    {
        await context.Response.WriteAsJsonAsync(new { success = false, message = "Invalid data." });
    }
});

// Handle user login
app.MapPost("/login", async (HttpContext context, AppDbContext db) =>
{
    var request = await JsonSerializer.DeserializeAsync<User>(context.Request.Body);

    var user = db.Users.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);

    if (user != null)
    {
        await context.Response.WriteAsJsonAsync(new { success = true, message = "Login successful!" });
    }
    else
    {
        await context.Response.WriteAsJsonAsync(new { success = false, message = "Invalid username or password." });
    }
});

app.Run();
