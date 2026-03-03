using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LeVinhTu_0577.Model;

namespace LeVinhTu_0577.ViewModel
{
    class DangNhap
    {
        private readonly SQL_SachEntities db;
        public DangNhap()
        {
            db = new SQL_SachEntities();
        }
        public bool DangNhapVM(string tenDN, string matKhau)
        {
            TAIKHOAN dn = db.TAIKHOAN.FirstOrDefault(tk => tk.TenDangNhap == tenDN && tk.MatKhau == matKhau);
            if (dn != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}