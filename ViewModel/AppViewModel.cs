using Doljniki.Model;
using Doljniki.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Doljniki.ViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private Doljnik selectedMraz;
        IFileService fileService;
        IDialogService dialogService;

        //сохраняет список должников
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                    (saveCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            if (dialogService.SaveFileDialog() == true)
                            {
                                fileService.Save(dialogService.FilePath, Mrazi.ToList());
                                dialogService.ShowMessage("Список мразей сохранен");
                            }
                        }
                        catch (Exception ex)
                        {
                            dialogService.ShowMessage(ex.Message);
                        }
                    }));
            }
        }
        //открытие файла должников
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get 
            {
                return openCommand ??
                    (openCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            if (dialogService.OpenFileDialog() == true)
                            {
                                var mrazi = fileService.Open(dialogService.FilePath);
                                Mrazi.Clear();
                                foreach (var m in mrazi)
                                    Mrazi.Add(m);
                                dialogService.ShowMessage("Поглядите на этих сволочей");
                            }
                        }
                        catch (Exception ex)
                        {
                            dialogService.ShowMessage(ex.Message);
                        }
                    }));
            }
        }
        //подтверждение закрытия файла на кнопку
        private RelayCommand acceptCommand;
        public  RelayCommand AcceptCommand
        {
            get
            {
                return acceptCommand ??
                    (acceptCommand = new RelayCommand(obj =>
                    {
                        Window window = obj as Window;
                        window.DialogResult = true;
                    }));
            }
        }
        //добавление новых жертв
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        Doljnik doljnik = new Doljnik();
                        SelectedMraz = doljnik;
                        if (dialogService.AddDialog(this) == true)
                        {
                            Mrazi.Insert(0, doljnik);
                            dialogService.ShowMessage("Должник успешно добавлен");
                        }
                        else
                            dialogService.ShowMessage("Отмена");
                    }));
            }
        }
        //удаляет должника из списка
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Doljnik doljnik = obj as Doljnik;
                        if (doljnik != null)
                        {
                            Mrazi.Remove(doljnik);
                        }
                    },
                    (obj) => Mrazi.Count > 0));
            }
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                (editCommand = new RelayCommand(obj =>
                {
                    int tmpSum = 0;
                    Doljnik doljnik = SelectedMraz;
                    tmpSum = doljnik.Sum;
                    if (dialogService.EditDialog(this) == true)
                    {
                        dialogService.ShowMessage("Сумма успешно изменена");
                    }
                    else
                    {
                        dialogService.ShowMessage("Отмена");
                        doljnik.Sum = tmpSum;
                    }
                }, (obj) =>
                {
                    Doljnik doljnik = SelectedMraz;
                    return doljnik != null;
                }));
            }
        }

        public ObservableCollection<Doljnik> Mrazi { get; set; }
        public Doljnik SelectedMraz
        {
            get { return selectedMraz; }
            set
            {
                selectedMraz = value;
                OnPropertyChanged("SelectedMraz");
            }
        }

        public AppViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;
            Mrazi = new ObservableCollection<Doljnik>
            {
                new Doljnik { Name = "Вася", Sum = 1000},
                new Doljnik { Name = "Леха", Sum = 1004}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
