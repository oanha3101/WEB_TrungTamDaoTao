// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Quan_Ly_TTDT.Data;
// using Quan_Ly_TTDT.Models;  // Đảm bảo rằng lớp User đã được định nghĩa tại đây

// var builder = WebApplication.CreateBuilder(args);

// // ✅ Đăng ký DbContext
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// // ✅ Đăng ký Identity với User tùy chỉnh
// builder.Services.AddDefaultIdentity<User>(options =>
// {
//     options.Password.RequireDigit = true;
//     options.Password.RequiredLength = 6;
// })
// .AddRoles<IdentityRole>() // Nếu có dùng RoleManager
// .AddEntityFrameworkStores<AppDbContext>();

// // ✅ Đăng ký session
// builder.Services.AddDistributedMemoryCache();
// builder.Services.AddSession(options =>
// {
//     options.IdleTimeout = TimeSpan.FromMinutes(30);
//     options.Cookie.HttpOnly = true;
//     options.Cookie.IsEssential = true;
// });

// builder.Services.AddControllersWithViews();

// var app = builder.Build();

// // ✅ Seed admin account
// // using (var scope = app.Services.CreateScope())
// // {
// //     var services = scope.ServiceProvider;
// //     var userManager = services.GetRequiredService<UserManager<User>>(); // Sử dụng User thay vì IdentityUser
// //     var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
// //     await SeedData.SeedAdminAsync(userManager, roleManager);
// // }

// // ✅ Middleware pipeline
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Home/Error");
//     app.UseHsts();
// }

// app.UseHttpsRedirection();
// app.UseStaticFiles();
// app.UseRouting();

// app.UseSession();
// app.UseAuthentication(); // Bắt buộc khi dùng Identity
// app.UseAuthorization();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

// app.Run();
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
app.UseRouting();

// ✅ Cấu hình middleware để sử dụng session
app.UseSession();  // Thêm middleware sử dụng session

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
