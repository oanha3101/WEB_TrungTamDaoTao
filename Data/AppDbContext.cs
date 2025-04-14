using Microsoft.EntityFrameworkCore;
using Quan_Ly_TTDT.Models;


namespace Quan_Ly_TTDT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet là đại diện cho bảng trong SQL Server
        public DbSet<HocVien> HocViens { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<DangKy> DangKys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<KhoaHoc>()
    .Property(k => k.HocPhi)
    .HasColumnType("decimal(18,2)");


            // Có thể cấu hình thêm ở đây nếu cần (quan hệ, ràng buộc...)
        }
    }
}
