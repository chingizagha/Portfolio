using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortfolioMVC.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
//var connectionString01 = builder.Configuration.GetConnectionString("PortfolioDatabase"); /*?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");*/
var connectionString02 = builder.Configuration.GetConnectionString("PortfolioMVC"); /*?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");*/

//if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
    builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString02));
//else
//    builder.Services.AddDbContext<AppDbContext>(options =>
//            options.UseSqlServer(connectionString01));

//builder.Services.BuildServiceProvider().GetService<AppDbContext>().Database.Migrate();


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();;


//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(connectionString));;

//var connectionString = builder.Configuration.GetConnectionString("PortfolioDatabase");


// Add services to the container.
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IGenericRepository<Career>, GenericRepository<Career>>();
builder.Services.AddScoped<IGenericRepository<Education>, GenericRepository<Education>>();
builder.Services.AddScoped<IGenericRepository<Skill>, GenericRepository<Skill>>();
builder.Services.AddScoped<IGenericRepository<Language>, GenericRepository<Language>>();
builder.Services.AddScoped<IGenericRepository<Tool>, GenericRepository<Tool>>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IGenericRepository<Image>, GenericRepository<Image>>();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    // app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "61dmin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
