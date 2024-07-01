using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap_B10.NhapNhanVien
{
    public class NhapCongDoanNhanVien
    {
        public static void NhapCongDoans(ThongTinNhanVien nhanVien)
        {
            while (true)
            {
                CongDoan congDoan = NhapCongDoan(nhanVien.Id);
                nhanVien.CongDoans.Add(congDoan);

                Console.Write("Bạn có muốn nhập thêm công đoạn cho nhân viên này? (Y/N): ");
                string response = Console.ReadLine().Trim().ToUpper();
                if (response != "Y")
                {
                    break;
                }
            }
        }

        public static CongDoan NhapCongDoan(int idNhanVien)
        {
            Console.WriteLine($"Nhập thông tin công đoạn cho nhân viên (ID: {idNhanVien}):");
            int maCongDoan = NhapMaCongDoan();
            string tenCongDoan = NhapTenCongDoan();
            int soLuongSanPham = NhapSoLuongSanPham();

            CongDoan congDoan = new CongDoan
            {
                MaCongDoan = maCongDoan,
                TenCongDoan = tenCongDoan,
                SoLuongSanPham = soLuongSanPham
            };

            return congDoan;
        }

        public static int NhapMaCongDoan()
        {
            int maCongDoan;
            do
            {
                Console.Write("Mã công đoạn: ");
                if (!int.TryParse(Console.ReadLine(), out maCongDoan) || maCongDoan <= 0)
                {
                    Console.WriteLine("Mã công đoạn phải là số nguyên dương. Vui lòng nhập lại.");
                }
            } while (maCongDoan <= 0);
            return maCongDoan;
        }

        public static string NhapTenCongDoan()
        {
            string tenCongDoan;
            do
            {
                Console.Write("Tên công đoạn: ");
                tenCongDoan = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(tenCongDoan) || !IsAllLetters(tenCongDoan))
                {
                    Console.WriteLine("Tên công đoạn không được để trống và chỉ được chứa các ký tự chữ. Vui lòng nhập lại.");
                }
            } while (string.IsNullOrEmpty(tenCongDoan) || !IsAllLetters(tenCongDoan));
            return tenCongDoan;
        }


        public static int NhapSoLuongSanPham()
        {
            int soLuong;
            do
            {
                Console.Write("Số lượng sản phẩm: ");
                if (!int.TryParse(Console.ReadLine(), out soLuong) || soLuong < 0)
                {
                    Console.WriteLine("Số lượng sản phẩm phải là số nguyên không âm. Vui lòng nhập lại.");
                }
            } while (soLuong < 0);
            return soLuong;
        }

        public static void NhapIdNhanVienVaThemCongDoan(List<ThongTinNhanVien> danhSachNhanVien)
        {
            Console.Write("Nhập ID nhân viên: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID không hợp lệ. Vui lòng nhập lại.");
                return;
            }

            ThongTinNhanVien nhanVien = danhSachNhanVien.FirstOrDefault(nv => nv.Id == id);
            if (nhanVien == null)
            {
                Console.WriteLine("Không tìm thấy nhân viên với ID này.");
                return;
            }

            NhapCongDoans(nhanVien);
            Console.WriteLine("Đã thêm công đoạn cho nhân viên.");
        }
        private static bool IsAllLetters(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
