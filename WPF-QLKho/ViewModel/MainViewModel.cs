using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_QLKho.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        // mọi thứ xử lý sẽ nằm trong này
        public ICommand LoadedWindowCommand { get; set; }
        public MainViewModel()
        {
            //MessageBox.Show("Đã vào trong MainViewModel -> DataContext của mainwindow.xaml");

            //When MainWindow is loaded > run LoginWindow
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {

                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

            });
            
            
        }
    }
}
