using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GardenControl.Data;
using GardenControl.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("GardenControlContextConnection") ?? throw new InvalidOperationException("Connection string 'GardenControlContextConnection' not found.");

//builder.Services.AddDbContext<GardenControlContext>(options => options.UseSqlServer(connectionString));
//Conexion a la base de datos
builder.Services.AddDbContext<GardenControlContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<GardenControlUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<GardenControlContext>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
