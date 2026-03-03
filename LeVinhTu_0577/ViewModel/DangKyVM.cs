using LeVinhTu_0577.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeVinhTu_0577.ViewModel
{
    class DangKyVM
    {
        private readonly SQL_SachEntities db;

        public DangKyVM()
        {
            db = new SQL_SachEntities();
        }

        public string DangKy_VM(string tenDN, string matKhau, string nhapLai)
        {
            if (string.IsNullOrWhiteSpace(tenDN) ||
                string.IsNullOrWhiteSpace(matKhau) ||
                string.IsNullOrWhiteSpace(nhapLai))
            {
                return "Vui lòng nhập đầy đủ thông tin";
            }

            if (matKhau != nhapLai)
            {
                return "Mật khẩu nhập lại không khớp";
            }

            var exist = db.TAIKHOAN.FirstOrDefault(tk => tk.TenDangNhap == tenDN);
            if (exist != null)
            {
                return "Tên đăng nhập đã tồn tại";
            }

            var tkMoi = new TAIKHOAN
            {
                TenDangNhap = tenDN,
                MatKhau = matKhau
            };

            db.TAIKHOAN.Add(tkMoi);
            db.SaveChanges();

            return "OK";
        }
    }
}
