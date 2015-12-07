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
using Windows.Phone.UI.Input;

namespace TravelListAppG7
{
    sealed partial class MainPage: Page
    {

        private DomainController dc;
        public MainPage()
        {
            this.InitializeComponent();
            HardwareButtons.BackPressed += OnBackPressed;
            dc = DomainController.Instance;
        }

             
        private async void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ButtonLogin.IsEnabled = false;
                ButtonRegister.IsEnabled = false;
                var userItem = new User { Username = TextUsername.Text, Password = TextPassword.Text };
                await dc.Register(userItem);
                HardwareButtons.BackPressed -= OnBackPressed;
                Frame.Navigate(typeof(HomePage));
            }
            catch (Exception ex) {
                MessageDialog msgbox = new MessageDialog(ex.Message);
                await msgbox.ShowAsync();
            }
            finally {
                ButtonLogin.IsEnabled = true;
                ButtonRegister.IsEnabled = true;
            }
        }

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ButtonLogin.IsEnabled = false;
                ButtonRegister.IsEnabled = false;
                await dc.Login(TextUsername.Text, TextPassword.Text);
                HardwareButtons.BackPressed -= OnBackPressed;
                Frame.Navigate(typeof(HomePage));
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
        private async void OnBackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            e.Handled = true;
            HardwareButtons.BackPressed -= OnBackPressed;
            // add your own code here to run when Back is pressed
            Application.Current.Exit();
        }

    }
}
