using TravelListAppG7.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TravelListAppG7.Domain;
using TravelListAppG7.DataModel;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
using System.Threading.Tasks;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace TravelListAppG7.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FriendView : Page
    {
        private DomainController dc;
        public FriendView()
        {
            dc = DomainController.Instance;
            this.InitializeComponent();
            HardwareButtons.BackPressed += OnBackPressed;
         }

       
        private async void OnBackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            e.Handled = true;
            HardwareButtons.BackPressed -= OnBackPressed;
            // add your own code here to run when Back is pressed
            Frame.Navigate(typeof(HomePage));
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DataContext = null;
                this.DataContext = new CollectionViewSource { Source = await dc.findFriend(txtUserName.Text) };
            }
            catch (Exception ex) {
                MessageDialog msgbox = new MessageDialog(ex.Message);
                await msgbox.ShowAsync();
            }
        }
        private async void FriendDest_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await Task.Delay(50);
            TravelList selected = FriendDest.SelectedItem as TravelList;
            dc.destinationFriend = selected;
            HardwareButtons.BackPressed -= OnBackPressed;
            Frame.Navigate(typeof(FriendPackingItems));
        }


    }
}
