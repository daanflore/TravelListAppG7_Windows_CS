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

namespace TravelListAppG7
{
    sealed partial class MainPage: Page
    {
        private MobileServiceCollection<User, User> users;
        private IMobileServiceTable<User> userTable = App.MobileService.GetTable<User>();
        private DomainController dc;
        public MainPage()
        {
            this.InitializeComponent();
            dc = DomainController.Instance;
        }

        private async Task Register(User userItem)
        {
            await userTable.InsertAsync(userItem);
            dc.user = userItem;
            


        }

        

       
        private async void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var userItem = new User { Username = TextUsername.Text, Password = TextPassword.Text };
            await Register(userItem);
        }

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //await userTable.ToString();
            }
            catch (Exception ex) {
                
            }
            
        }

        private async void CheckBoxComplete_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            TodoItem item = cb.DataContext as TodoItem;
            
        }
    }
}
