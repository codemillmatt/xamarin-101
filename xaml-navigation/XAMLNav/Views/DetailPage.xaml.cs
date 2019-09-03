using Xamarin.Forms;

namespace XAMLNav
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(DetailPageViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
