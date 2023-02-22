using BakeTRy.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BaketryLocalDbConnection") ?? throw new InvalidOperationException("Connection string 'BaketryDBContextConnection' not found.");

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

// Enable Controllers and Views
builder.Services.AddControllersWithViews().AddJsonOptions(options => {
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddRazorPages();

// Injecting Repositories
builder.Services.AddScoped<IPastryRepository, PastryRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(serviceProvider => ShoppingCart.GetCart(serviceProvider));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// EF Core 
builder.Services.AddDbContext<BaketryDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:BaketryLocalDbConnection"])
) ; 

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BaketryDBContext>();


var app = builder.Build();

//-------------------------------------------------------------------------------------------
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapRazorPages();




// Trigger Data Seed if it's the initial run after EF Core migration.
//DBSeedData.Seed(app);

app.Run();
