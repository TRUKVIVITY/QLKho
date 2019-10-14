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
    public class SupplierViewModel: BaseViewModel
    {
        #region Initializing ICommand!
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        #endregion

        #region for Binding index to Textbox when selected in listview changed!
        private Supplier _SelectedItem;
        public Supplier SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SupplierNameVM = SelectedItem.SupplierName;
                    AddressVM = SelectedItem.sAddress;
                    PhoneVM = SelectedItem.Phone;
                    EmailVM = SelectedItem.Email;
                    ContractDateVM = SelectedItem.ContractDate;
                    MoreInfoVM = SelectedItem.MoreInfo;

                }
            }
        }

        private string _SupplierNameVM;
        public string SupplierNameVM { get => _SupplierNameVM; set { _SupplierNameVM = value; OnPropertyChanged(); } }

        private string _AddressVM;
        public string AddressVM { get => _AddressVM; set { _AddressVM = value; OnPropertyChanged(); } }

        private string _PhoneVM;
        public string PhoneVM { get => _PhoneVM; set { _PhoneVM = value; OnPropertyChanged(); } }

        private string _EmailVM;
        public string EmailVM { get => _EmailVM; set { _EmailVM = value; OnPropertyChanged(); } }

        private System.DateTime? _ContractDateVM;
        public System.DateTime? ContractDateVM { get => _ContractDateVM; set { _ContractDateVM = value; OnPropertyChanged(); } }

        private string _MoreInfoVM;
        public string MoreInfoVM { get => _MoreInfoVM; set { _MoreInfoVM = value; OnPropertyChanged(); } }
        #endregion

        private ObservableCollection<Supplier> _List;
        public ObservableCollection<Supplier> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        public SupplierViewModel()
        {
            List = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Suppliers);

            AddCommand = new RelayCommand<object>((p) =>
            {
                #region The Condition (Điều kiện) for can't execute AddCommnad!
                // if Textbox Binding SupplierNameVM null or empty > can't execute!
                if (string.IsNullOrEmpty(SupplierNameVM))
                    return false;
                ///*Select * from Supplier where SupplierName = SupplierNameVM*/
                var displayList = DataProvider.Ins.DB.Suppliers.Where(x => x.SupplierName == SupplierNameVM /*&& x.sAddress == AddressVM*/ && x.Phone == PhoneVM && x.Email == EmailVM /*&& x.MoreInfo == MoreInfoVM*//* && x.ContractDate == ContractDateVM*/);
                ///*displayList invalid or displayList exist > can't execute!*/
                if (displayList == null || displayList.Count() != 0)
                    return false;
                #endregion

                return true;

            }, (p) =>
            {
                #region Execute!
                var Supplier = new Supplier() { SupplierName = SupplierNameVM, Phone = PhoneVM, sAddress = AddressVM, Email = EmailVM, MoreInfo = MoreInfoVM, ContractDate = ContractDateVM };
                DataProvider.Ins.DB.Suppliers.Add(Supplier);
                DataProvider.Ins.DB.SaveChanges();

                //show list in listview without call Database
                List.Add(Supplier);
                #endregion
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                //Item in ListView didn't selected 
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Suppliers.Where(x =>x.Id == SelectedItem.Id && x.SupplierName == SupplierNameVM && x.sAddress == AddressVM && x.Phone == PhoneVM && x.Email == EmailVM && x.MoreInfo == MoreInfoVM && x.ContractDate == ContractDateVM);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                var Supplier = DataProvider.Ins.DB.Suppliers.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                Supplier.SupplierName = SupplierNameVM;
                Supplier.Phone = PhoneVM;
                Supplier.sAddress = AddressVM;
                Supplier.Email = EmailVM;
                Supplier.ContractDate = ContractDateVM;
                Supplier.MoreInfo = MoreInfoVM;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.SupplierName = SupplierNameVM;
            });
        }
    }
}
