using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using LeVinhTu_0577.Model;

namespace LeVinhTu_0577.View
{
    /// <summary>
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        DispatcherTimer timer;
        public DangNhap()
        {
            InitializeComponent();
            db = new SQL_SachEntities();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
                                                  
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            txt_timeBox.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }
        private readonly SQL_SachEntities db;

        private void DangNhap_C(object sender, RoutedEventArgs e)
        {
            TAIKHOAN dn = db.TAIKHOAN.FirstOrDefault
                (tk => tk.TenDangNhap == txt_tenDN.Text && tk.MatKhau == txt_MK.Text);
            if (dn != null)
            {
                MainWindow m = new MainWindow();
                m.Show();
            }
            else MessageBox.Show("Sai tên ĐN hoặc MK");
        }

        private void DangKy_C(object sender, RoutedEventArgs e)
        {
            var dk = new DangKy();
            dk.ShowDialog();
        }
    }
}
