using DeepMavawala.BookStore.Data;
using DeepMavawala.BookStore.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionstring = "Server=localhost;Database=BookStore;User=root;Password=;";
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookStoreContext>(options => options.UseMySql(connectionstring,ServerVersion.AutoDetect(connectionstring)));
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddScoped<BookRepository,BookRepository>();
builder.Services.AddScoped<LanguageRepository,LanguageRepository>();
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
