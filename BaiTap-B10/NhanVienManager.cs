using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiTap_B10.ChucNangManager;
using BaiTap_B10.NhapNhanVien;

namespace BaiTap_B10
{
    // Lớp NhanVienManager để quản lý danh sách nhân viên
    public class NhanVienManager : INhanVienManager
    {
        private List<ThongTinNhanVien> danhSachNhanVien;
        private int currentId;
        private NhanVienDisplay nhanVienDisplay;

        public NhanVienManager()
        {
            danhSachNhanVien = new List<ThongTinNhanVien>();
            currentId = 1;
            nhanVienDisplay = new NhanVienDisplay();
        }

        public void HienThiNhanVien()
        {
            nhanVienDisplay.HienThiNhanVien(danhSachNhanVien);
        }
        public void ThemNhanVienBanPhim()
        {
            ThongTinNhanVien nhanVien = NhapThongTinNhanVien.ThemNhanVien();
            nhanVien.Id = currentId++;
            danhSachNhanVien.Add(nhanVien);
            Console.WriteLine("Nhân viên đã được thêm thành công!");
        }

        public void ThemCongDoanNhanVien()
        {
            NhapCongDoanNhanVien.NhapIdNhanVienVaThemCongDoan(danhSachNhanVien);
        }

        public void ThemNhanVienExcel()
        {
            Console.Write("Nhập đường dẫn tệp Excel: ");
            string filePath = Console.ReadLine();

            List<ThongTinNhanVien> nhanViensTuExcel = NhapNhanVienExcel.ThemNhanVienExcel(filePath);

            // Thêm các nhân viên từ danh sách nhận được từ Excel vào danh sách quản lý
            foreach (var nhanVien in nhanViensTuExcel)
            {
                nhanVien.Id = currentId++;
                danhSachNhanVien.Add(nhanVien);
            }

            Console.WriteLine("Thêm nhân viên từ Excel thành công!");

        }


    }
}
