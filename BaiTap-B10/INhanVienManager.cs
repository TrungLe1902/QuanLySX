using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap_B10
{
     public interface INhanVienManager
    {
        void ThemNhanVienBanPhim();
        void ThemCongDoanNhanVien();
        void ThemNhanVienExcel();
        void HienThiNhanVien();
    }

    public interface IChucNangManager
    {
        void TimNhanVien();
       
        void XuatBaoCaoSanLuong(string filePath);
    }
   
}
