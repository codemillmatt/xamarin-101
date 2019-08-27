using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace XAMLNav
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

            NoteSelectedCommand = new Command(async() =>
            {
                if (SelectedNote == null)
                    return;

                var detailVm = new DetailPageViewModel();
                detailVm.TheNote = SelectedNote;

                await Application.Current.MainPage.Navigation.PushAsync(
                    new DetailPage(detailVm)
                );

                SelectedNote = null;
            });
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

        string selectedNote;
        public string SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedNote)));
            }
        }

        public Command NoteSelectedCommand { get; }

        public ObservableCollection<string> Notes { get; set; }
        
        public Command SaveNoteCommand { get; }
        public Command EraseNoteCommand { get; }
    }
}
