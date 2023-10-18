using Interface_Dependency_Injection.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// I added
builder.Services.AddDbContext<iakademi47Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("iakademi47connection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// I added
builder.Services.AddScoped<IProductRepository, SQLProductRepository>();

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
