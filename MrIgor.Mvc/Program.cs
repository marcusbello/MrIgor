using System.Composition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using MrIgor.Core.Models;
using MrIgor.Core.Services;
using MrIgor.Infrastructure.Data;
using MrIgor.Mvc.Authorization.Handlers;
using MrIgor.Mvc.Authorization.Requirements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
// if you are using SQL Server
string? sqlServerConnection = builder.Configuration
 .GetConnectionString("MrIgorDBConnection");
if (sqlServerConnection is null)
{
    Console.WriteLine("SQL Server database connection string is missing!");
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(sqlServerConnection));
}
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<AspNetUser, AspNetRole>(options => options.User.RequireUniqueEmail = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.LoginPath = "/Identity/Account/Login";
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("RequireTenant", policy =>
    {
        policy.Requirements.Add(new TenantRequirement(new[] { "SuperAdmin", "Admin", "Teacher", "Student" }));
    });

builder.Services.AddSingleton<IAuthorizationHandler, TenantRequirementHandler>();

builder.Services.AddScoped<ITenantService, TenantService>();

builder.Services.AddTransient<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
