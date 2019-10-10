using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_QLKho.Model;

namespace WPF_QLKho.ViewModel
{
    public class UnitViewModel : BaseViewModel
    {
        private ObservableCollection<Unit> _List;
        public ObservableCollection<Unit> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Unit _SelectedItem;
        public Unit SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    UnitName = SelectedItem.UnitName;
                }
            }
        }

        private string _UnitName;
        public string UnitName { get => _UnitName; set { _UnitName = value; OnPropertyChanged(); } }


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public UnitViewModel()
        {
            List = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(UnitName))
                    return false;

                var displayList = DataProvider.Ins.DB.Units.Where(x => x.UnitName == UnitName);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                var unit = new Unit() { UnitName = UnitName };

                DataProvider.Ins.DB.Units.Add(unit);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(unit);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(UnitName) || SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Units.Where(x => x.UnitName == UnitName);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                var unit = DataProvider.Ins.DB.Units.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                unit.UnitName = UnitName;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.UnitName = UnitName;
            });
        }
    }
}
