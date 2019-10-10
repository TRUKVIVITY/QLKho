using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_QLKho.Model;

namespace WPF_QLKho.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        // mọi thứ xử lý sẽ nằm trong này

        //kiểu ObservableCollection sẽ cập nhập ngay dữ liệu lên listview khi có dữ liệu thay đổi.
        private ObservableCollection<TonKho> _tonKhoList;
        public ObservableCollection<TonKho> TonKhoList
        {
            get => _tonKhoList;
            set
            {
                _tonKhoList = value;
                OnPropertyChanged();
            }
        }
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
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                if (p == null)
                {
                    return;
                }
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

                if (loginWindow.DataContext == null)
                {
                    return;
                }
                var loginVM = loginWindow.DataContext as LoginViewModel;
                if (loginVM.IsLogin)
                {
                    p.Show();
                    LoadTonKho();
                }
                else
                {
                    p.Close();
                }

            });

            InputCommand = new RelayCommand<object>((p) => { return true; }, (p) => { InputWindow wd = new InputWindow(); wd.ShowDialog(); });
            OutputCommand = new RelayCommand<object>((p) => { return true; }, (p) => { OutputWindow wd = new OutputWindow(); wd.ShowDialog(); });
            ObjectCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ObjectWindow wd = new ObjectWindow(); wd.ShowDialog(); });
            //When Click Button include {Binding UnitCommand} => UnitWindow show with dialog status.
            UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) => {UnitWindow wd = new UnitWindow(); wd.ShowDialog();});
            SuplierCommand = new RelayCommand<object>((p) => { return true; }, (p) => { SuplierWindow wd = new SuplierWindow(); wd.ShowDialog(); });
            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CustomerWindow wd = new CustomerWindow(); wd.ShowDialog(); });
            UserCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UserWindow wd = new UserWindow(); wd.ShowDialog(); });

            //MessageBox.Show(DataProvider.Ins.DB.Users.First().DisplayName);

        }

        void LoadTonKho()
        {
            TonKhoList = new ObservableCollection<TonKho>();

            var objectList = DataProvider.Ins.DB.tObjects;
            int i = 1;
            foreach(var item in objectList)
            {
                var inputList = DataProvider.Ins.DB.InputInfoes.Where(x => x.IdObject == item.Id);
                var outputList = DataProvider.Ins.DB.OutputInfoes.Where(x => x.IdObject == item.Id);

                int sumInput = 0;
                int sumOutput = 0;

                if (inputList != null)
                {
                    sumInput = (int)inputList.Sum(x => x.Counts);
                }
                if(outputList != null)
                {
                    sumOutput = (int)outputList.Sum(x => x.Counts);
                }

                TonKho tonKho = new TonKho();
                tonKho.STT = i;
                tonKho.Count = sumInput - sumOutput;
                tonKho.tObject = item;

                TonKhoList.Add(tonKho);

                i++;
            }
            
        }
    }
}
