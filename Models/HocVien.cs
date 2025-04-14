using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quan_Ly_TTDT.Models
{
    public class HocVien
    {
        [Key]
        public int MaHocVien { get; set; }

        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string SoDienThoai { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TaiKhoan { get; set; } = string.Empty;
        public string MatKhau { get; set; } = string.Empty;

        public virtual ICollection<DangKy> DangKys { get; set; } = new List<DangKy>();
    }
}
