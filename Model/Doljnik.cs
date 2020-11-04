using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Doljniki.Model
{
    public class Doljnik : INotifyPropertyChanged
    {
        private string name;
        private int sum;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Sum
        {
            get { return sum; }
            set
            {
                if (value < 0)
                    sum = 0;
                else
                    sum = value;
                OnPropertyChanged("Sum");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
