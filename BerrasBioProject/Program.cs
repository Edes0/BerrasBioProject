using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BerrasBioProject.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BerrasBioProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BerrasBioProject")));

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
    pattern: "{controller=Home}/{action=Index}");

app.Run();


// TODO: Sort function in show
// TODO: Cannot book more than existing spots in show