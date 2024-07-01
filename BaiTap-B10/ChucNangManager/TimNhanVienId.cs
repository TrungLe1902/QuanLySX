using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiTap_B10.ChucNangManager
{
    public class QuanLyNhanVien
    {
        private List<ThongTinNhanVien> danhSachNhanVien;

        public QuanLyNhanVien(List<ThongTinNhanVien> danhSachNhanVien)
        {
            this.danhSachNhanVien = danhSachNhanVien;
        }

        public void TimNhanVien()
        {
            Console.Write("Nhập ID nhân viên cần tìm: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID không hợp lệ. Vui lòng nhập lại.");
                return;
            }
        }


    }
}
