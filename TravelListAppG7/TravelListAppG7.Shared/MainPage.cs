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


namespace TravelListAppG7
{
    sealed partial class MainPage: Page
    {
        private MobileServiceCollection<User, User> users;
        private IMobileServiceTable<User> userTable = App.MobileService.GetTable<User>();
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async Task InsertTodoItem(TodoItem todoItem)
        {
            // This code inserts a new TodoItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            //await todoTable.InsertAsync(todoItem);
            //items.Add(todoItem);

            //await SyncAsync(); // offline sync
        }

        

        private async Task UpdateCheckedTodoItem(TodoItem item)
        {
            // This code takes a freshly completed TodoItem and updates the database. When the MobileService 
            // responds, the item is removed from the list 
            //await todoTable.UpdateAsync(item);
            //items.Remove(item);
            //ListItems.Focus(Windows.UI.Xaml.FocusState.Unfocused);

            //await SyncAsync(); // offline sync
        }

        private async void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await userTable.
            }
            catch (Exception ex) {
                
            }
            
        }

        private async void CheckBoxComplete_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            TodoItem item = cb.DataContext as TodoItem;
            await UpdateCheckedTodoItem(item);
        }
    }
}
