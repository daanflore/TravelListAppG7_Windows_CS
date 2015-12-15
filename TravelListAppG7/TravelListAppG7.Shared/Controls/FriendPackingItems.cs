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
using TravelListAppG7.DataModel;
using Windows.UI.Popups;

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
            TxtItem.IsEnabled = false;
            
        }

        public async void fillContext()
        {

            this.DataContext = new CollectionViewSource { Source = await dc.getFriendPAckingItems() };
            DestCombo.DataContext= new CollectionViewSource { Source = await dc.GetUserDestinations() };
            TravelList selected= (TravelList) DestCombo.SelectedItem;
            dc.destination = selected;
            CatCombo.DataContext = new CollectionViewSource { Source = await selected.getTravelLists() };
            
        }

        private async void OnBackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
            
            // add your own code here to run when Back is pressed
            if (StandardPopup.IsOpen) {
                StandardPopup.IsOpen = false;
            }
            else {
                HardwareButtons.BackPressed -= OnBackPressed;
                Frame.Navigate(typeof(FriendView));
            }

        }
        private void FriendPacked_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PopupGrid.Width = Window.Current.Bounds.Width;
            PopupGrid.Height = Window.Current.Bounds.Height;
            StandardPopup.HorizontalOffset = (Window.Current.Bounds.Width - PopupGrid.Width) / 2;
            StandardPopup.VerticalOffset = (Window.Current.Bounds.Height - PopupGrid.Height) / 2;
            PackingItem packed = (PackingItem)FriendPacked.SelectedItem;
            TxtItem.Text = packed.Name;
            TxtAmount.Text = packed.Amount.ToString();
            StandardPopup.IsOpen = true;
        }
        private async void DestCombo_DropDownClosed(object sender, object e)
        {
            CatCombo.IsEnabled = false;
            TravelList selected =(TravelList) DestCombo.SelectedItem;
            dc.destination=selected;
            CatCombo.DataContext= new CollectionViewSource { Source = await selected.getTravelLists() };
            CatCombo.IsEnabled = true;
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            StandardPopup.IsOpen = false;
        }
        private async void add_Click(object sender, RoutedEventArgs e)
        {
            try {
                Categorie selected = (Categorie)CatCombo.SelectedItem;
                dc.categorie = selected;
                add.IsEnabled = false;
                cancel.IsEnabled = false;
                int amount;
                int.TryParse(TxtAmount.Text, out amount);
                dc.addPackingItem(new PackingItem { Name = TxtItem.Text, Amount = amount });
                StandardPopup.IsOpen = false;
            }
            catch (ArgumentException ex)
            {
                MessageDialog msgbox = new MessageDialog(ex.Message);
                await msgbox.ShowAsync();
            }
            finally
            {
                add.IsEnabled = true;
                cancel.IsEnabled = true;
            }
        }


    }
}
