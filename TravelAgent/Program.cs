using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using TravelAgent.Data;

Env.Load();
var builder = WebApplication.CreateBuilder(args);
//
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowTravel",
        policy => policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        );


});


var connectionString = Env.GetString("DB_CONNECTION");

// Configure the database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseCors("AllowTravel");

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
