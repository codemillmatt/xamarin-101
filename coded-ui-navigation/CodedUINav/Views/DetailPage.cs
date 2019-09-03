using Xamarin.Forms;

namespace CodedUINav
{
    public class DetailPage : ContentPage
    {
        public DetailPage(DetailPageViewModel viewModel)
        {
            BindingContext = viewModel;

            Title = "Notes Detail";

            var textLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            textLabel.SetBinding(Label.TextProperty, nameof(DetailPageViewModel.NoteText));

            var exitButton = new Button
            {
                Text = "Pop",
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            exitButton.SetBinding(Button.CommandProperty, nameof(DetailPageViewModel.ExitCommand));

            var stackLayout = new StackLayout();
            stackLayout.Children.Add(textLabel);
            stackLayout.Children.Add(exitButton);

            Content = stackLayout;
        }
    }
}