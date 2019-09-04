using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace XAMLUI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected void SaveButton_Clicked(object sender, EventArgs e)
        {
            var noteText = noteEditor.Text;

            noteEditor.Text = string.Empty;

            textLabel.Text = noteText;
        }

        protected void DeleteButton_Clicked(object sender, EventArgs e)
        {
            noteEditor.Text = string.Empty;
            textLabel.Text = string.Empty;
        }
    }
}
