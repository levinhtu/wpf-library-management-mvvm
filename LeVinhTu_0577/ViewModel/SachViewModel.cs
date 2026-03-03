using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LeVinhTu_0577.Model;

namespace LeVinhTu_0577.ViewModel   
{
    class SachViewModel
    {
        private readonly SQL_SachEntities db;
        public SachViewModel()
        {
            db = new SQL_SachEntities();
        }
        public List<SACH> LoadGridS()
        {
            List<SACH> dsS = db.SACH.ToList();
            return dsS;
        }
        public List<LOAI> LoadComboLoai()
        {
            List<LOAI> dsLoai = db.LOAI.ToList();
            return dsLoai;
        }
        public void ThemVM(String maS, String tens, String maloai, DateTime ngayxb)
        {
            SACH sThem = null;
            try
            {
                sThem = new SACH();
                sThem.MaSach = maS;
                sThem.TenSach = tens;
                sThem.MaLoai = maloai;
                sThem.NgayXuatBan = ngayxb;
                db.SACH.Add(sThem);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Trùng mã hoặc sai kiểu dữ liệu");
            }

        }
        public void SuaVM(String mas, String tens, String maloai, DateTime ngayxb)
        {
            SACH sSua = db.SACH.FirstOrDefault(s => s.MaSach == mas);
            if (sSua != null)
            {
                sSua.MaSach = mas;
                sSua.TenSach = tens;
                sSua.MaLoai = maloai;
                sSua.NgayXuatBan = ngayxb;
                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("Sửa thành công");
                }
                else MessageBox.Show("Sửa thất bại");
            }
            else MessageBox.Show("Không có để sửa");
        }
        public string XoaVM(string maS)
        {
            var sXoa = db.SACH.FirstOrDefault(s => s.MaSach == maS);

            if (sXoa == null)
                return "Không tìm thấy sách";

            db.SACH.Remove(sXoa);
            db.SaveChanges();
            return "OK";
        }
        public List<SACH> TimVM(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return db.SACH.ToList();

            return db.SACH
                     .Where(s => s.MaSach.Contains(key) ||
                                 s.TenSach.Contains(key))
                     .ToList();
        }
        public int DemSoSach()
        {
            return db.SACH.Count();
        }

        public int DemSoSachTheoDanhSach(List<SACH> ds)
        {
            if (ds == null) return 0;
            return ds.Count;
        }
        public List<SACH> LocTheoTheLoai(string maLoai)
        {
            if (string.IsNullOrWhiteSpace(maLoai))
                return db.SACH.ToList();

            return db.SACH
                     .Where(s => s.MaLoai == maLoai)
                     .ToList();
        }
    }
}