using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XAMLNav
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(DetailPageViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;
        }
    }
}
