using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTap_B10
{
    class Program
    {
        static void Main(string[] args)
        {
            INhanVienManager qlsx = new NhanVienManager();
            IChucNangManager cnql = new ChucNangManager.ChucNangManager(); 
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("===== MENU =====");
                Console.WriteLine("1. Thêm nhân viên");
                Console.WriteLine("2. Thêm công đoan cho nhân viên");
                Console.WriteLine("3. Xuất báo cáo sản lượng");
                Console.WriteLine("4. Tìm kiếm nhân viên");
                Console.WriteLine("5. Hiển thị nhân viên");
                Console.Write("Nhập lựa chọn của bạn: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                    Console.Write("Nhập lựa chọn của bạn: ");
                }

                switch (choice)
                {
                    case 1:
                        qlsx.ThemNhanVienBanPhim();
                        break;
                    case 2:
                        qlsx.ThemCongDoanNhanVien();
                        break;
                    case 3:
                        Console.Write("Nhập đường dẫn và tên file (vd: BaoCaoSanLuong.xlsx): ");
                        string filePath = Console.ReadLine().Trim(); // Nhập đường dẫn và tên file, xoá khoảng trắng dư thừa                       
                        cnql.XuatBaoCaoSanLuong(filePath);

                        break;
                    case 4:                      
                        cnql.TimNhanVien();
                        qlsx.HienThiNhanVien();
                        break;
                    case 5:
                        qlsx.HienThiNhanVien();
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }
    }
}
