using System.Windows;
using LeVinhTu_0577.ViewModel;

namespace LeVinhTu_0577.View
{
    public partial class DangKy : Window
    {
        // Dùng ViewModel, KHÔNG dùng DangKy ở đây nữa
        private readonly DangKyVM vm = new DangKyVM();

        public DangKy()
        {
            InitializeComponent();
        }

        private void Huy_C(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DangKy_C(object sender, RoutedEventArgs e)
        {
            // Nếu txt_MK_DK, txt_MK_XN là TextBox
            string result = vm.DangKy_VM(
                txt_tenDK.Text,
                txt_MK_DK.Text,
                txt_MK_XN.Text
            );

            // Nếu bạn dùng PasswordBox thì đổi .Text -> .Password

            if (result == "OK")
            {
                MessageBox.Show("Đăng ký thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show(result);
            }
        }
    }
}
