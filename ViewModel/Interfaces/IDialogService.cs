using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doljniki.ViewModel.Interfaces
{
    public interface IDialogService
    {
        void ShowMessage(string message);
        string FilePath { get; set; }
        bool OpenFileDialog();
        bool SaveFileDialog();
        bool AddDialog(INotifyPropertyChanged vm);
        bool EditDialog(INotifyPropertyChanged vm);
    }
}
