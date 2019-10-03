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
        
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }
        public ICommand ObjectCommand { get; set; }
        public ICommand UnitCommand { get; set; }
        public ICommand SuplierCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand UserCommand { get; set; }

        public MainViewModel()
        {
            //MessageBox.Show("Đã vào trong MainViewModel -> DataContext của mainwindow.xaml");

            //When MainWindow is loaded > run LoginWindow
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {

                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

            });

            InputCommand = new RelayCommand<object>((p) => { return true; }, (p) => { InputWindow wd = new InputWindow(); wd.ShowDialog(); });
            OutputCommand = new RelayCommand<object>((p) => { return true; }, (p) => { OutputWindow wd = new OutputWindow(); wd.ShowDialog(); });
            ObjectCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ObjectWindow wd = new ObjectWindow(); wd.ShowDialog(); });
            //When Click Button include {Binding UnitCommand} => UnitWindow show with dialog status.
            UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) => {UnitWindow wd = new UnitWindow(); wd.ShowDialog();});
            SuplierCommand = new RelayCommand<object>((p) => { return true; }, (p) => { SuplierWindow wd = new SuplierWindow(); wd.ShowDialog(); });
            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CustomerWindow wd = new CustomerWindow(); wd.ShowDialog(); });
            UserCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UserWindow wd = new UserWindow(); wd.ShowDialog(); });


        }
    }
}
