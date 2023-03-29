using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DeepMavawala.Ecommerce.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using DeepMavawala.Ecommerce.Models;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DeepMavawalaEcommerceContextConnection");
var connectionString = builder.Configuration.GetConnectionString("DeepMavawalaEcommerceContextConnection") ?? throw new InvalidOperationException("Connection string 'DeepMavawalaEcommerceContextConnection' not found.");

builder.Services.AddDbContext<DeepMavawalaEcommerceContext>(options =>
    options.UseMySql(connection,ServerVersion.AutoDetect(connection), b => b.SchemaBehavior(MySqlSchemaBehavior.Translate,
    (schema, entity) => $"{schema ?? "dbo"}_{entity}")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<DeepMavawalaEcommerceContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DeepMavawalaEcommerceContext>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
