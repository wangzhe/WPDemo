using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace MiniBrowser
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Go_Click(object sender, RoutedEventArgs e)  //this is more VC++ mode
        {
            string site = URL.Text;
            MiniBrowser.Navigate(new Uri(site, UriKind.Absolute));
        }

        private void New_Page_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/Second.xaml?val={0}", "haha"), UriKind.Relative));
        }
    }
}