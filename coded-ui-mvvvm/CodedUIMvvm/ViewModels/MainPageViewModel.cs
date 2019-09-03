using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace CodedUIMvvm
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            Notes = new ObservableCollection<NoteModel>();

            SaveNoteCommand = new Command(() =>
            {
                Notes.Add(new NoteModel { Text = NoteText });
                NoteText = string.Empty;
            },
            () => !string.IsNullOrEmpty(NoteText));

            EraseNoteCommand = new Command(() => NoteText = string.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(NoteText)));

                SaveNoteCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<NoteModel> Notes { get; }

        public Command SaveNoteCommand { get; }
        public Command EraseNoteCommand { get; }
    }
}
