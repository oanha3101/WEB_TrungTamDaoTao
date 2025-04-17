// using Microsoft.AspNetCore.Identity;
// using Quan_Ly_TTDT.Models;
// using Quan_Ly_TTDT.Data;

// // public static class SeedData
// // {

// //     public static async Task SeedAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
// //     {
// //         // 1. Tạo role "Admin" nếu chưa có
// //         if (!await roleManager.RoleExistsAsync("Admin"))
// //         {
// //             await roleManager.CreateAsync(new IdentityRole("Admin"));
// //         }

// //         // 2. Tạo tài khoản admin mặc định nếu chưa có
// //         string adminEmail = "admin@gmail.com";
// //         string adminPassword = "Admin@123";

// //         var adminUser = await userManager.FindByEmailAsync(adminEmail);
// //         if (adminUser == null)
// //         {
// //             var user = new User
// //             {
// //                 UserName = adminEmail,  // Hoặc TenTaiKhoan nếu bạn muốn sử dụng TenTaiKhoan làm tên tài khoản
// //                 Email = adminEmail,
// //                 EmailConfirmed = true
// //             };

// //             var result = await userManager.CreateAsync(user, adminPassword);
// //             if (result.Succeeded)
// //             {
// //                 await userManager.AddToRoleAsync(user, "Admin");
// //             }
// //         }
// //     }

// // }
// public static class SeedData
// {
//     public static async Task SeedAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
//     {
//         // Tạo Role "Admin" nếu chưa có
//         var roleExists = await roleManager.RoleExistsAsync("Admin");
//         if (!roleExists)
//         {
//             await roleManager.CreateAsync(new IdentityRole("Admin"));
//         }

//         // Tạo tài khoản admin nếu chưa có
//         var adminUser = await userManager.FindByEmailAsync("admin@yourdomain.com");
//         if (adminUser == null)
//         {
//             adminUser = new User
//             {
//                 UserName = "admin@yourdomain.com",
//                 Email = "admin@yourdomain.com",

//             };
//             var result = await userManager.CreateAsync(adminUser, "Password123!"); // Mật khẩu admin
//             if (result.Succeeded)
//             {
//                 await userManager.AddToRoleAsync(adminUser, "Admin"); // Thêm vào role Admin
//             }
//         }
//     }
// }
