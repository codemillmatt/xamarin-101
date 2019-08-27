using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace XAMLNav
{
    public class DetailPageViewModel : INotifyPropertyChanged
    {
        public DetailPageViewModel()
        {
            ExitCommand = new Command(async () =>
                await Application.Current.MainPage.Navigation.PopAsync()
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;

        string theNote;
        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(
                    nameof(TheNote)));
            }
        }

        public ICommand ExitCommand { get; }
    }
}
