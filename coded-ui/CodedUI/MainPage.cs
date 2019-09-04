using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace CodedUI
{
    public class MainPage : ContentPage
    {
        readonly Editor noteEditor;
        readonly Label textLabel;

        public MainPage()
        {
            On<iOS>().SetUseSafeArea(true);

            BackgroundColor = Color.PowderBlue;

            var xamagonImage = new Image
            {
                Source = "xamagon"
            };

            noteEditor = new Editor
            {
                Placeholder = "Enter Note",
                Margin = new Thickness(10, 10),
                BackgroundColor = Color.White
            };

            var saveButton = new Button
            {
                Text = "Save",
                Margin = new Thickness(10, 10),
                BackgroundColor = Color.Green,
                TextColor = Color.White
            };
            saveButton.Clicked += SaveButton_Clicked;

            var deleteButton = new Button
            {
                Text = "Delete",
                Margin = new Thickness(10, 10),
                BackgroundColor = Color.Red,
                TextColor = Color.White
            };
            deleteButton.Clicked += DeleteButton_Clicked;

            textLabel = new Label
            {
                FontSize = 20,
                Margin = new Thickness(10)
            };

            var grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1.0, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(2.5, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1.0, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(2.0, GridUnitType.Star) },
                }
            };

            grid.Children.Add(xamagonImage, 0, 0);
            Grid.SetColumnSpan(xamagonImage, 2);

            grid.Children.Add(noteEditor, 0, 1);
            Grid.SetColumnSpan(noteEditor, 2);

            grid.Children.Add(saveButton, 0, 2);
            grid.Children.Add(deleteButton, 1, 2);

            grid.Children.Add(textLabel, 0, 3);
            Grid.SetColumnSpan(textLabel, 2);

            Content = grid;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var noteText = noteEditor.Text;

            noteEditor.Text = string.Empty;

            textLabel.Text = noteText;
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            noteEditor.Text = string.Empty;
            textLabel.Text = string.Empty;
        }
    }
}
