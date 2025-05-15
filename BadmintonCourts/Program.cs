using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BadmintonCourts.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BadmintonCourtsDbContextConnection") ?? throw new InvalidOperationException("Connection string 'BadmintonCourtsDbContextConnection' not found.");

builder.Services.AddDbContext<BadmintonCourtsDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<BadmintonCourtsUser>(options => options.SignIn.RequireConfirmedAccount = false)
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<BadmintonCourtsDbContext>();

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
app.MapRazorPages();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin","User" };

        foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        await roleManager.CreateAsync(new IdentityRole(role));

    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<BadmintonCourtsUser>>();

    string adminEmail = "admin@gmail.com";
    string adminPassword = "Password123!";

    if(await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var user = new BadmintonCourtsUser();
        user.UserName = adminEmail;
        user.Email = adminEmail;
        user.FirstName = "Test";
        user.LastName = "Admin";
        user.Phone = "1234567890";

        await userManager.CreateAsync(user, adminPassword);
        await userManager.AddToRoleAsync(user, "Admin");
    }
}

app.Run();
