using Doljniki.Model;
using Doljniki.View;
using Doljniki.ViewModel.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Doljniki.ViewModel.Classes
{
    class DefaultDialogService : IDialogService
    {
        public string FilePath { get; set; }
        public Doljnik TmpDoljnik { get; set; } //нарушаю mvvm-паттерн

        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }
        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }

        public bool AddDialog(INotifyPropertyChanged vm)
        {
            AddDoljnik doljnikAdd = new AddDoljnik(vm);
            return doljnikAdd.ShowDialog() == true;
        }

        public bool EditDialog(INotifyPropertyChanged vm)
        {
            EditDoljnik editDoljnik = new EditDoljnik(vm);
            return editDoljnik.ShowDialog() == true;
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
