using Site.Data.Interfaces;
using Site.Data.Mocks;
using Site.Data;
using Microsoft.EntityFrameworkCore;
using Site.Data.Repository;
using Site.Data.Models;


var builder = WebApplication.CreateBuilder(args);

var _confString = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("dbsettings.json")
    .Build();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Регистрация интерфейса и его реализации
builder.Services.AddDbContext<AppDbContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IAllCars, CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();
builder.Services.AddTransient<IAllOrders, OrdersRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCar.GetCar(sp));

builder.Services.AddMemoryCache();
builder.Services.AddSession();


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

app.UseSession();

app.UseRouting();

app.UseAuthorization();

//app.UseMvcWithDefaultRoute();
//app.UseMvc(routes =>
//{
//    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}"),
//})



//using (var scope = app.ApplicationServices.CreateScope())
//{
//    AppDbContent content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
//    DBObjects.Initial(content);
//}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContent>();
    DBObjects.Initial(context);
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
