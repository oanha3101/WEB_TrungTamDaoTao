using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Quan_Ly_TTDT.Models;


public class KhoaHoc
{
    [Key]
    public int MaKhoaHoc { get; set; }

    public string TenKhoaHoc { get; set; } = string.Empty;

    public string GiangVien { get; set; } = string.Empty;

    public string ThoiGianKhaiGiang { get; set; } = string.Empty;

    public decimal HocPhi { get; set; }

    public int SoLuongToiDa { get; set; }

    public virtual ICollection<DangKy> DangKys { get; set; } = new List<DangKy>();
}
