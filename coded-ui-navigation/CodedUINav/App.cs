using Xamarin.Forms;

namespace CodedUINav
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
