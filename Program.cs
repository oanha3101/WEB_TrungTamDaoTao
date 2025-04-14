using Microsoft.EntityFrameworkCore;
using Quan_Ly_TTDT.Data; // namespace chứa AppDbContext (sửa theo đúng tên của bạn)

var builder = WebApplication.CreateBuilder(args);

// 🧠 Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// 🧠 Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HTTP Strict Transport Security
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // <-- cái này để load css/js/image

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
