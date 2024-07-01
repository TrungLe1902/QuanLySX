using System;
using System.Collections.Generic;

namespace BaiTap_B10.ChucNangManager
{
    public class NhanVienDisplay
    {
        public void HienThiNhanVien(List<ThongTinNhanVien> danhSachNhanVien)
        {
            if (danhSachNhanVien.Count == 0)
            {
                Console.WriteLine("Không có nhân viên nào trong danh sách.");
                return;
            }

            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-5} {4,-15} {5,-15} {6,-10} {7,-15}",
                "ID", "Tên", "Giới tính", "Tuổi", "Lương cơ bản", "Hệ số lương", "Phụ cấp", "Tổng lương");
            Console.WriteLine(new string('-', 100));

            foreach (var nhanVien in danhSachNhanVien)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-5} {4,-15:C} {5,-15:F2} {6,-10:C} {7,-15:C}",
                    nhanVien.Id, nhanVien.Ten, nhanVien.GioiTinh, nhanVien.Tuoi, nhanVien.LuongCoBan.ToString("N0"), nhanVien.HeSoLuong.ToString("N1"), nhanVien.PhuCap.ToString("N0"), nhanVien.TongLuong.ToString("N0"));

                Console.WriteLine("Danh sách công đoạn:");
                Console.WriteLine("{0,-15} {1,-20} {2,-15}", "Mã công đoạn", "Tên công đoạn", "Số lượng sản phẩm");
                Console.WriteLine(new string('-', 50));

                foreach (var congDoan in nhanVien.CongDoans)
                {
                    Console.WriteLine("{0,-15} {1,-20} {2,-15}", congDoan.MaCongDoan, congDoan.TenCongDoan, congDoan.SoLuongSanPham);
                }

                Console.WriteLine(new string('-', 100));
            }
        }
    }
}
