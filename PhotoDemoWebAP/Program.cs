using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using PhotoDemoWebAP.AppServices;
using PhotoDemoWebAP.DBLib;
using PhotoDemoWebAP.DBLib.Repositories.Implements;
using PhotoDemoWebAP.DBLib.Repositories.Interfaces;
using PhotoDemoWebAP.Utilities;

var logger = LogManager.GetCurrentClassLogger();
var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Host.UseNLog();

//setup DI
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IGroupOrderRepository, GroupOrderRepository>();
builder.Services.AddTransient<IProductAppService>(x => new ProductAppService(x.GetRequiredService<IProductRepository>(),
    x.GetRequiredService<IBundleProductRepository>()));
builder.Services.AddTransient<IOrderAppService>(x => new OrderAppService(x.GetRequiredService<IOrderRepository>(),
    x.GetRequiredService<IGroupOrderRepository>()));

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

DBTools.ConnectionString= builder.Configuration.GetConnectionString("Localdb");
CacheManager.PullProductDataInCache();
CacheManager.PullBundleProductModelInCache();

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
    pattern: "{controller=Home}/{action=Product}/{id?}");

app.Run();
