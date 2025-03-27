using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BadmintonCourts.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BadmintonCourtsDbContextConnection") ?? throw new InvalidOperationException("Connection string 'BadmintonCourtsDbContextConnection' not found.");

builder.Services.AddDbContext<BadmintonCourtsDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<BadmintonCourtsUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BadmintonCourtsDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
