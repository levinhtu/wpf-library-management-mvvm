using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LeVinhTu_0577
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Ghi đè StartupUri trước khi nó được sử dụng
            //this.Startup += new StartupEventHandler(App_Startup);
            this.Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            this.StartupUri = new Uri("View/DangNhap.xaml", UriKind.Relative);
            //this.StartupUri = new Uri("View/MainWindow.xaml", UriKind.Relative);
        }
    }
}
