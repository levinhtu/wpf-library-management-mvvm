using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LeVinhTu_0577.ViewModel;
using LeVinhTu_0577.Model;

namespace LeVinhTu_0577
{
    public partial class MainWindow : Window
    {
        private readonly SachViewModel sVM;

        public MainWindow()
        {
            InitializeComponent();
            sVM = new SachViewModel();
            LoadComboLoai();
            LoadGridS();
        }
        public void LoadGridS()
        {
            List<SACH> dsGridS = sVM.LoadGridS();
            dg_Sach.ItemsSource = dsGridS;

            txt_DemSach.Text = "Tổng số sách: " + sVM.DemSoSachTheoDanhSach(dsGridS);
        }
        public void LoadComboLoai()
        {
            cb_TheLoai.ItemsSource = sVM.LoadComboLoai();
            cb_TheLoai.DisplayMemberPath = "TenLoai";
            cb_TheLoai.SelectedValuePath = "MaLoai";

            if (cb_TheLoai.Items.Count > 0)
                cb_TheLoai.SelectedIndex = 0;
        }
        
        private void dg_Sach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Sach.SelectedItem is SACH s)
            {
                txt_MaSach.Text = s.MaSach;
                txt_TenSach.Text = s.TenSach;
                cb_TheLoai.SelectedValue = s.MaLoai;
                date_NgayXB.SelectedDate = s.NgayXuatBan;
            }
        }
        
        private void Them(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaSach.Text) ||
                string.IsNullOrWhiteSpace(txt_TenSach.Text) ||
                cb_TheLoai.SelectedValue == null ||
                !date_NgayXB.SelectedDate.HasValue)
            {
                MessageBox.Show("Vui lòng nhập đủ Mã sách, Tên sách, Thể loại và Ngày xuất bản");
                return;
            }

            sVM.ThemVM(
                txt_MaSach.Text,
                txt_TenSach.Text,
                cb_TheLoai.SelectedValue.ToString(),
                date_NgayXB.SelectedDate.Value
            );

            LoadGridS();
        }
        private void Sua(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaSach.Text))
            {
                MessageBox.Show("Vui lòng chọn sách cần sửa");
                return;
            }

            if (cb_TheLoai.SelectedValue == null || !date_NgayXB.SelectedDate.HasValue)
            {
                MessageBox.Show("Vui lòng chọn Thể loại và Ngày xuất bản");
                return;
            }

            sVM.SuaVM(
                txt_MaSach.Text,
                txt_TenSach.Text,
                cb_TheLoai.SelectedValue.ToString(),
                date_NgayXB.SelectedDate.Value
            );

            LoadGridS();
        }
        private void Xoa(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaSach.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Mã sách cần xoá");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xoá sách này?", "Xoá",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            string kq = sVM.XoaVM(txt_MaSach.Text);

            if (kq == "OK")
            {
                MessageBox.Show("Xoá thành công");
                LoadGridS();
            }
            else
            {
                MessageBox.Show(kq); // "Không tìm thấy sách"
            }
        }
        private void LoadLai(object sender, RoutedEventArgs e)
        {
            txt_MaSach.Clear();
            txt_TenSach.Clear();
            txt_Tim.Clear();

            if (cb_TheLoai.Items.Count > 0)
                cb_TheLoai.SelectedIndex = 0;

            date_NgayXB.SelectedDate = DateTime.Now;

            LoadGridS();
        }
        private void date_NgayXB_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txt_namThu != null && date_NgayXB.SelectedDate.HasValue)
            {
                int namThu = DateTime.Now.Year - date_NgayXB.SelectedDate.Value.Year + 1;
                txt_namThu.Text = namThu.ToString();
            }
        }
        private void Tim(object sender, RoutedEventArgs e)
        {
            var ds = sVM.TimVM(txt_Tim.Text);

            dg_Sach.ItemsSource = ds;
            txt_DemSach.Text = "Tổng số sách: " + sVM.DemSoSachTheoDanhSach(ds);
        }
        private void cb_TheLoai_DropDownClosed(object sender, EventArgs e)
        {
            if (cb_TheLoai.SelectedValue == null)
                return;

            string maLoai = cb_TheLoai.SelectedValue.ToString();
            var ds = sVM.LocTheoTheLoai(maLoai);

            dg_Sach.ItemsSource = ds;
            txt_DemSach.Text = "Tổng số sách: " + sVM.DemSoSachTheoDanhSach(ds);
        }
    }
}
