using Doljniki.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace Doljniki
{
    /// <summary>
    /// Логика взаимодействия для AddDoljnik.xaml
    /// </summary>
    public partial class AddDoljnik : Window
    {
        public AddDoljnik(INotifyPropertyChanged vm)
        {
            InitializeComponent();

            DataContext = vm;
        }
    }
}
