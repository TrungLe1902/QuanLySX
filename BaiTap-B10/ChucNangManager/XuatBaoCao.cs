using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace BaiTap_B10.ChucNangManager
{
    public class XuatBaoCao
    {
        public static void XuatBaoCaoSanLuong(List<ThongTinNhanVien> danhSachNhanVien, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Thiết lập LicenseContext

            try
            {
                using (ExcelPackage excel = new ExcelPackage())
                {
                    excel.Workbook.Worksheets.Add("BaoCaoSanLuong");
                    var worksheet = excel.Workbook.Worksheets["BaoCaoSanLuong"];

                    // Tiêu đề
                    worksheet.Cells[1, 1].Value = "ID Nhân Viên";
                    worksheet.Cells[1, 2].Value = "Tên Nhân Viên";
                    worksheet.Cells[1, 3].Value = "Giới Tính";
                    worksheet.Cells[1, 4].Value = "Tuổi";
                    worksheet.Cells[1, 5].Value = "Lương Cơ Bản";
                    worksheet.Cells[1, 6].Value = "Hệ Số Lương";
                    worksheet.Cells[1, 7].Value = "Phụ Cấp";
                    worksheet.Cells[1, 8].Value = "Mã Công Đoạn";
                    worksheet.Cells[1, 9].Value = "Tên Công Đoạn";
                    worksheet.Cells[1, 10].Value = "Số Lượng Sản Phẩm";

                    int row = 2;
                    foreach (var nhanVien in danhSachNhanVien)
                    {
                        if (nhanVien.CongDoans.Count > 0)
                        {
                            foreach (var congDoan in nhanVien.CongDoans)
                            {
                                worksheet.Cells[row, 1].Value = nhanVien.Id;
                                worksheet.Cells[row, 2].Value = nhanVien.Ten;
                                worksheet.Cells[row, 3].Value = nhanVien.GioiTinh;
                                worksheet.Cells[row, 4].Value = nhanVien.Tuoi;
                                worksheet.Cells[row, 5].Value = nhanVien.LuongCoBan;
                                worksheet.Cells[row, 6].Value = nhanVien.HeSoLuong;
                                worksheet.Cells[row, 7].Value = nhanVien.PhuCap;
                                worksheet.Cells[row, 8].Value = congDoan.MaCongDoan;
                                worksheet.Cells[row, 9].Value = congDoan.TenCongDoan;
                                worksheet.Cells[row, 10].Value = congDoan.SoLuongSanPham;
                                row++;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Nhân viên {nhanVien.Id} ({nhanVien.Ten}) không có công đoạn.");
                        }
                    }

                    FileInfo excelFile = new FileInfo(filePath);
                    try
                    {
                        excel.SaveAs(excelFile);
                        Console.WriteLine("Báo cáo đã được xuất ra file: " + filePath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi lưu file Excel: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi trong quá trình tạo file Excel: {ex.Message}");
            }
        }
    }
}
