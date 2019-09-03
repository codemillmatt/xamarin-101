using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace CodedUIMvvm
{
    public class MainPage: ContentPage
    {
        public MainPage()
        {
            On<iOS>().SetUseSafeArea(true);

            BindingContext = new MainPageViewModel();

            var noteEditor = new Editor
            {
                Placeholder = "Enter Note",
                Margin = new Thickness(10, 10)
            };
            noteEditor.SetBinding(Editor.TextProperty, nameof(MainPageViewModel.NoteText));

            var saveButton = new Button
            {
                Text = "Save",
                Margin = new Thickness(10, 10),
                BackgroundColor = Color.Green,
                TextColor = Color.White
            };
            saveButton.SetBinding(Button.CommandProperty, nameof(MainPageViewModel.SaveNoteCommand));

            var deleteButton = new Button
            {
                Text = "Delete",
                Margin = new Thickness(10, 10),
                BackgroundColor = Color.Red,
                TextColor = Color.White
            };
            deleteButton.SetBinding(Button.CommandProperty, nameof(MainPageViewModel.EraseNoteCommand));

            var collectionView = new CollectionView
            {
                ItemTemplate = new NotesTemplate()
            };
            collectionView.SetBinding(CollectionView.ItemsSourceProperty, nameof(MainPageViewModel.Notes));

            var grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) }
                },
                RowDefinitions =
                {
                    new RowDefinition{ Height = new GridLength(2.5, GridUnitType.Star) },
                    new RowDefinition{ Height = new GridLength(0.5, GridUnitType.Star) },
                    new RowDefinition{ Height = new GridLength(2.0, GridUnitType.Star) },
                }
            };

            grid.Children.Add(noteEditor, 0, 0);
            Grid.SetColumnSpan(noteEditor, 2);

            grid.Children.Add(saveButton, 0, 1);
            grid.Children.Add(deleteButton, 1, 1);

            grid.Children.Add(collectionView, 0, 2);
            Grid.SetColumnSpan(collectionView, 2);

            Content = grid;
        }

        class NotesTemplate : DataTemplate
        {
            public NotesTemplate() : base(LoadTemplate)
            {

            }

            static StackLayout LoadTemplate()
            {
                var textLabel = new Label();
                textLabel.SetBinding(Label.TextProperty, nameof(NoteModel.Text));

                var frame = new Frame
                {
                    VerticalOptions = LayoutOptions.Center,
                    Content = textLabel
                };

                return new StackLayout
                {
                    Children = { frame },
                    Padding = new Thickness(10, 10)
                };
            }
        }
    }
}
