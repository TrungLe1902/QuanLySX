using System;
using System.Collections.Generic;

namespace BaiTap_B10.ChucNangManager
{
    public class ChucNangManager : IChucNangManager
    {
        private List<ThongTinNhanVien> danhSachNhanVien;
        private QuanLyNhanVien quanLyNhanVien;

        public ChucNangManager()
        {
            danhSachNhanVien = new List<ThongTinNhanVien>(); // Khởi tạo danh sách nhân viên
            quanLyNhanVien = new QuanLyNhanVien(danhSachNhanVien); // Khởi tạo đối tượng QuanLyNhanVien
        }

        public void TimNhanVien()
        {
            quanLyNhanVien.TimNhanVien();
        }

        public void XuatBaoCaoSanLuong(string filePath)
        {
            try
            {
                XuatBaoCao.XuatBaoCaoSanLuong(danhSachNhanVien, filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xuất báo cáo sản lượng: {ex.Message}");
            }
        }
    }
}
