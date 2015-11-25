using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TravelListAppG7.DataModel;
using TravelListAppG7.Domain;
using TravelListAppG7.Controls;

namespace TravelListAppG7
{
    sealed partial class MainPage: Page
    {

        private DomainController dc;
        public MainPage()
        {
            this.InitializeComponent();
            dc = DomainController.Instance;
        }

             
        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var userItem = new User { Username = TextUsername.Text, Password = TextPassword.Text };
            dc.Register(userItem);
            Frame.Navigate(typeof(TravelDestinationList));
        }

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ButtonLogin.IsEnabled = false;
                ButtonRegister.IsEnabled = false;
                await dc.Login(TextUsername.Text, TextPassword.Text);
                Frame.Navigate(typeof(TravelDestinationList));
            }
            catch (Exception ex)
            {
                MessageDialog msgbox = new MessageDialog(ex.Message);
                await msgbox.ShowAsync();
            }
            finally {
                ButtonLogin.IsEnabled = true;
                ButtonRegister.IsEnabled = true;
            }
        }

    }
}
