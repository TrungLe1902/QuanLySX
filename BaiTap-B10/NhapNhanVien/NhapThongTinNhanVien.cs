using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiTap_B10.NhapNhanVien
{
    public static class NhapThongTinNhanVien
    {
        public static ThongTinNhanVien ThemNhanVien()
        {
            Console.WriteLine("Nhập thông tin nhân viên mới:");
            string ten = NhapTenNhanVien();
            string gioiTinh = NhapGioiTinhNhanVien();
            int tuoi = NhapTuoiNhanVien();
            decimal luongCoBan = NhapLuongCoBan();
            decimal heSoLuong = NhapHeSoLuong();
            decimal phuCap = NhapPhuCap();
            ThongTinNhanVien nhanVien = new ThongTinNhanVien
            {
                Id = 0, // Sẽ được gán sau khi thêm vào danh sách
                Ten = ten,
                GioiTinh = gioiTinh,
                Tuoi = tuoi,
                LuongCoBan = luongCoBan,
                HeSoLuong = heSoLuong,
                PhuCap = phuCap,
                CongDoans = new List<CongDoan>() // Khởi tạo danh sách công đoạn rỗng
            };        
            return nhanVien;
        }
        //=================================== Nhâp thông tin cho nhân viên =============================
        public static string NhapTenNhanVien()
        {
            string ten;
            do
            {
                Console.Write("Tên nhân viên: ");
                ten = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(ten) || !IsValidNameWithSpaces(ten))
                {
                    Console.WriteLine("Tên nhân viên chỉ được chứa các ký tự chữ cái và khoảng trắng, không được để trống hoặc chứa số. Vui lòng nhập lại.");
                }
            } while (string.IsNullOrEmpty(ten) || !IsValidNameWithSpaces(ten));
            return ten;
        }

        private static bool IsValidNameWithSpaces(string name)
        {
            return name.Replace(" ", "").All(char.IsLetter);
        }


        public static string NhapGioiTinhNhanVien()
        {
            string gioiTinh;
            do
            {
                Console.Write("Giới tính nhân viên ('Nam' hoặc 'Nu'): ");
                gioiTinh = Console.ReadLine().Trim();
                if (gioiTinh != "Nam" && gioiTinh != "Nu")
                {
                    Console.WriteLine("Giới tính sinh viên chỉ có thể là 'Nam' hoặc 'Nữ'. Vui lòng nhập lại.");
                }
            } while (gioiTinh != "Nam" && gioiTinh != "Nu");
            return gioiTinh;
        }

        public static int NhapTuoiNhanVien()
        {
            int tuoi;
            do
            {
                Console.Write("Tuổi Nhân viên: ");
                if (!int.TryParse(Console.ReadLine(), out tuoi) || tuoi <= 0 || tuoi >= 100)
                {
                    Console.WriteLine("Tuổi nhân viên phải là một số nguyên dương nhỏ hơn 100. Vui lòng nhập lại.");
                }
            } while (tuoi <= 0 || tuoi >= 100);
            return tuoi;
        }

        public static decimal NhapLuongCoBan()
        {
            decimal luongCoBan;
            do
            {
                Console.Write("Lương cơ bản: ");
                if (!decimal.TryParse(Console.ReadLine(), out luongCoBan) || luongCoBan <= 0)
                {
                    Console.WriteLine("Lương cơ bản phải là một số dương. Vui lòng nhập lại.");
                }
            } while (luongCoBan <= 0);
            return luongCoBan;
        }

        public static decimal NhapHeSoLuong()
        {
            decimal heSoLuong;
            do
            {
                Console.Write("Hệ số lương: ");
                if (!decimal.TryParse(Console.ReadLine(), out heSoLuong) || heSoLuong <= 0 || heSoLuong >= 5)
                {
                    Console.WriteLine("Hệ số lương phải là một số dương lớn hơn 0 và nhỏ hơn 5. Vui lòng nhập lại.");
                }
            } while (heSoLuong <= 0 || heSoLuong >= 5);
            return heSoLuong;
        }

        public static decimal NhapPhuCap()
        {
            decimal phuCap;
            do
            {
                Console.Write("Phụ cấp: ");
                if (!decimal.TryParse(Console.ReadLine(), out phuCap) || phuCap < 0)
                {
                    Console.WriteLine("Phụ cấp phải là một số không âm. Vui lòng nhập lại.");
                }
            } while (phuCap < 0);
            return phuCap;
        }

      }
}
