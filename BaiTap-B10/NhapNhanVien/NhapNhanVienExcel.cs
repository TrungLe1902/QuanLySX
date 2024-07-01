using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace BaiTap_B10.NhapNhanVien
{
    internal class NhapNhanVienExcel
    {
        public static List<ThongTinNhanVien> ThemNhanVienExcel(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            List<ThongTinNhanVien> danhSachNhanVien = new List<ThongTinNhanVien>();

            FileInfo fileInfo = new FileInfo(filePath);

            try
            {
                using (ExcelPackage package = new ExcelPackage(fileInfo))

                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Lấy sheet đầu tiên

                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) // Bắt đầu từ hàng thứ hai (hàng đầu tiên là tiêu đề)
                    {
                        string ten = GetCellValue(worksheet, row, 1); 
                        string gioiTinh = GetCellValue(worksheet, row, 2); 
                        string tuoiStr = GetCellValue(worksheet, row, 3); 
                        string luongCoBanStr = GetCellValue(worksheet, row, 4); 
                        string heSoLuongStr = GetCellValue(worksheet, row, 5); 
                        string phuCapStr = GetCellValue(worksheet, row, 6);

                        // Kiểm tra và xử lý dữ liệu
                        if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(gioiTinh) || string.IsNullOrEmpty(tuoiStr) ||
                            string.IsNullOrEmpty(luongCoBanStr) || string.IsNullOrEmpty(heSoLuongStr) || string.IsNullOrEmpty(phuCapStr))
                        {
                            // Bỏ qua nếu bất kỳ trường nào cũng không được nhập
                            continue;
                        }

                        int tuoi;
                        if (!int.TryParse(tuoiStr, out tuoi))
                        {
                            // Xử lý lỗi khi không thể chuyển đổi tuổi sang kiểu int
                            Console.WriteLine($"Lỗi ở hàng {row}: Tuổi không hợp lệ.");
                            continue;
                        }

                        decimal luongCoBan;
                        if (!decimal.TryParse(luongCoBanStr, out luongCoBan))
                        {
                            // Xử lý lỗi khi không thể chuyển đổi lương cơ bản sang kiểu decimal
                            Console.WriteLine($"Lỗi ở hàng {row}: Lương cơ bản không hợp lệ.");
                            continue;
                        }

                        decimal heSoLuong;
                        if (!decimal.TryParse(heSoLuongStr, out heSoLuong))
                        {
                            // Xử lý lỗi khi không thể chuyển đổi hệ số lương sang kiểu decimal
                            Console.WriteLine($"Lỗi ở hàng {row}: Hệ số lương không hợp lệ.");
                            continue;
                        }

                        decimal phuCap;
                        if (!decimal.TryParse(phuCapStr, out phuCap))
                        {
                            // Xử lý lỗi khi không thể chuyển đổi phụ cấp sang kiểu decimal
                            Console.WriteLine($"Lỗi ở hàng {row}: Phụ cấp không hợp lệ.");
                            continue;
                        }

                        // Kiểm tra giới tính
                        if (!IsValidGender(gioiTinh))
                        {
                            // Xử lý lỗi khi giới tính không hợp lệ
                            Console.WriteLine($"Lỗi ở hàng {row}: Giới tính không hợp lệ.");
                            continue;
                        }

                        // Tạo đối tượng ThongTinNhanVien và thêm vào danh sách
                        ThongTinNhanVien nhanVien = new ThongTinNhanVien();
                        nhanVien.Ten = ten;
                        nhanVien.GioiTinh = gioiTinh;
                        nhanVien.Tuoi = tuoi;
                        nhanVien.LuongCoBan = luongCoBan;
                        nhanVien.HeSoLuong = heSoLuong;
                        nhanVien.PhuCap = phuCap;

                        danhSachNhanVien.Add(nhanVien);
                    }
                }

                Console.WriteLine("Đọc tệp Excel thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }

            return danhSachNhanVien;
        }

        private static string GetCellValue(ExcelWorksheet worksheet, int row, int column)
        {
            var cellValue = worksheet.Cells[row, column].Value;
            return cellValue == null ? null : cellValue.ToString().Trim();
        }

        private static bool IsValidGender(string gioiTinh)
        {
            // Kiểm tra giới tính có nằm trong danh sách giới tính hợp lệ (Nam, Nu)
            return gioiTinh == "Nam" || gioiTinh == "Nu";
        }
    }
}
