using System;
using System.ComponentModel.DataAnnotations;

namespace Quan_Ly_TTDT.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Ho { get; set; }

        [Required]
        public string TenTaiKhoan { get; set; } // Tên tài khoản riêng biệt

        [Required]
        public string Ten { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string SoDienThoai { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        // Mặc định User, Admin sẽ set riêng nếu có phân quyền
        public string Role { get; set; } = "User";
    }
}
