using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductCategoryApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Servisleri burada yapýlandýrýn
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ProductService>(); // HttpClient'i ProductService'e enjekte et

var app = builder.Build();

// Middleware yapýlandýrmasý
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
