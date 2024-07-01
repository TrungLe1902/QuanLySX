using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap_B10
{
    public class CongDoan
    {
        public int MaCongDoan { get; set; }
        public string TenCongDoan { get; set; }
        public int SoLuongSanPham { get; set; }
    }
    public class ThongTinNhanVien
    {
        // Các thuộc tính của nhân viên
        public int Id { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public int Tuoi { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal HeSoLuong { get; set; }
        public decimal PhuCap { get; set; }
        public decimal TongLuong
        {
            get { return LuongCoBan * HeSoLuong + PhuCap; }
        }
        public List<CongDoan> CongDoans { get; set; } = new List<CongDoan>();

    }
}
