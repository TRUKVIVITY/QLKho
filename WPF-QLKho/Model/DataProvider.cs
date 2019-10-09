using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_QLKho.Model
{
    class DataProvider
    {
        private static DataProvider _ints;
        public static DataProvider Ins
        {
            get
            {
                if (_ints == null)
                    _ints = new DataProvider();
                return _ints;
            }
            set
            {
                _ints = value;
            }
        }
        public QLKhoEntities DB { get; set; }

        private DataProvider()
        {
            DB = new QLKhoEntities();
        }
    }
}
