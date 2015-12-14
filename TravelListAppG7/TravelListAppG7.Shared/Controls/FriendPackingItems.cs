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
using Windows.Phone.UI.Input;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace TravelListAppG7.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FriendPackingItems : Page
    {


        private DomainController dc;
        public FriendPackingItems()
        {
            dc = DomainController.Instance;
            this.InitializeComponent();
            HardwareButtons.BackPressed += OnBackPressed;
            fillContext();
            
        }

        public async void fillContext()
        {

            this.DataContext = new CollectionViewSource { Source = await dc.getFriendPAckingItems() };
            DestCombo.DataContext= new CollectionViewSource { Source = await dc.GetUserDestinations() };
        }

        private async void OnBackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            e.Handled = true;
            HardwareButtons.BackPressed -= OnBackPressed;
            // add your own code here to run when Back is pressed
            if (StandardPopup.IsOpen) {
                StandardPopup.IsOpen = false;
            }
            else {
            Frame.Navigate(typeof(HomePage));
            }

        }
        private void FriendPacked_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PopupGrid.Width = Window.Current.Bounds.Width;
            PopupGrid.Height = Window.Current.Bounds.Height;
            StandardPopup.HorizontalOffset = (Window.Current.Bounds.Width - PopupGrid.Width) / 2;
            StandardPopup.VerticalOffset = (Window.Current.Bounds.Height - PopupGrid.Height) / 2;
            StandardPopup.IsOpen = true;
        }



    }
}
