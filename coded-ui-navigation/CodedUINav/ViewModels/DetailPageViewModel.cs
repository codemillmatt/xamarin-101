using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CodedUINav
{
    public class DetailPageViewModel : INotifyPropertyChanged
    {
        public DetailPageViewModel()
        {
            ExitCommand = new Command(async () => await Application.Current.MainPage.Navigation.PopAsync());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));
            }
        }

        public ICommand ExitCommand { get; }
    }
}
