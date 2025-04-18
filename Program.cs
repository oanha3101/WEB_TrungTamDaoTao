using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quan_Ly_TTDT.Data;
using Quan_Ly_TTDT.Models;  // Đảm bảo rằng lớp User đã được định nghĩa tại đây


using Microsoft.EntityFrameworkCore;
using Quan_Ly_TTDT.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ✅ Đăng ký DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Đăng ký session
builder.Services.AddDistributedMemoryCache();  // Dịch vụ lưu trữ session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Cấu hình thời gian hết hạn session
    options.Cookie.HttpOnly = true;  // Bảo mật session cookie
    options.Cookie.IsEssential = true;  // Cookie cần thiết cho ứng dụng
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// ✅ Cho phép sử dụng các file tĩnh như CSS, JS
app.UseStaticFiles();

app.UseRouting();

// ✅ Cấu hình middleware để sử dụng session
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
