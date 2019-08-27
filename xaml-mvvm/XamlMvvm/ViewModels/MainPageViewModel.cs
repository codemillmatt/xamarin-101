using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamlMvvm
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            Notes = new ObservableCollection<string>();

            SaveNoteCommand = new Command(() => {
                Notes.Add(NoteText);
                NoteText = string.Empty;
            }, () => {
                return !string.IsNullOrEmpty(NoteText);
            });

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

        public ObservableCollection<string> Notes { get; set; }
        
        public Command SaveNoteCommand { get; }
        public Command EraseNoteCommand { get; }
    }
}
