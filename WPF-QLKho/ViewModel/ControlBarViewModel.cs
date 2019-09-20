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
    public class ControlBarViewModel : BaseViewModel
    {
        #region command
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand MouseLeftButtonDownWindowCommand{ get; set; }
        
        #endregion
        public ControlBarViewModel()
        {
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null? false : true; }, (p) => {

                FrameworkElement window = GetWindowParent(p);
                //ép kiểu w window từ frameworkelement sang kiểu Window để có thể dùng đc command đóng Window 
                var w = window as Window;

                //Lỡ lấy nhầm thằng đéo phải Window? hay không lấy được! => w phải not null
                if(w != null)
                {
                    w.Close();
                }
            });

            MaximizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {

                FrameworkElement window = GetWindowParent(p);
                //ép kiểu w window từ frameworkelement sang kiểu Window để có thể dùng đc command đóng Window 
                var w = window as Window;

                //Lỡ lấy nhầm thằng đéo phải Window? hay không lấy được! => w phải not null
                if (w != null)
                {
                    if (w.WindowState != WindowState.Maximized)
                    {
                        w.WindowState = WindowState.Maximized;
                    }else
                    {
                        w.WindowState = WindowState.Normal;
                    }
                }
            });

            MinimizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {

                FrameworkElement window = GetWindowParent(p);
                //ép kiểu w window từ frameworkelement sang kiểu Window để có thể dùng đc command đóng Window 
                var w = window as Window;

                //Lỡ lấy nhầm thằng đéo phải Window? hay không lấy được! => w phải not null
                if (w != null)
                {
                    if (w.WindowState != WindowState.Minimized)
                    {
                        w.WindowState = WindowState.Minimized;
                    }
                    else
                    {
                        w.WindowState = WindowState.Maximized;
                    }
                }
            });

            MouseLeftButtonDownWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {

                FrameworkElement window = GetWindowParent(p);
                //ép kiểu w window từ frameworkelement sang kiểu Window để có thể dùng đc command đóng Window 
                var w = window as Window;

                //Lỡ lấy nhầm thằng đéo phải Window? hay không lấy được! => w phải not null
                if (w != null)
                {
                    //nắm controlbar drag :)
                    w.DragMove();
                }
            });

        }
        
        FrameworkElement GetWindowParent(UserControl p)
        {
             FrameworkElement parent =p;

            //when parent == null, parent is window!
            //if parent not null, parent get Parent from UserControl => return parent when parent = null
            while(parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }
            return parent;
        }
    }
}
