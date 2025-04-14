using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quan_Ly_TTDT.Models
{
    public class DangKy
    {
        [Key]
        public int MaDangKy { get; set; }

        public int MaHocVien { get; set; }

        public int MaKhoaHoc { get; set; }

        public DateTime NgayDangKy { get; set; }

        [ForeignKey("MaHocVien")]
        public virtual HocVien HocVien { get; set; } = new HocVien();

        [ForeignKey("MaKhoaHoc")]
        public virtual KhoaHoc KhoaHoc { get; set; } = new KhoaHoc();
    }
}
