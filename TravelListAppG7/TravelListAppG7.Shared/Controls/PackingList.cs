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
using System.Diagnostics;
using Windows.Phone.UI.Input;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace TravelListAppG7.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PackingList : Page
    {
        private DomainController dc;

        public PackingList()
        {
            this.InitializeComponent();
            dc = DomainController.Instance;
            HardwareButtons.BackPressed += OnBackPressed;
            fillContext();
        }

        public async void fillContext()
        {
            var contextzelf =await dc.GetCategoriePacking();
            this.DataContext = new CollectionViewSource { Source = await dc.GetCategoriePacking() };
        }

        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            // if the Popup is open, then close it
            TxtItem.Text = "";
            StandardPopup.IsOpen = false;
        }

        // Handles the Click event on the Button on the page and opens the Popup. 
        private void ShowPopupOffsetClicked(object sender, RoutedEventArgs e)
        {
            test.Width = Window.Current.Bounds.Width;
            test.Height = Window.Current.Bounds.Height;
            StandardPopup.HorizontalOffset = (Window.Current.Bounds.Width - test.Width) / 2;
            StandardPopup.VerticalOffset = (Window.Current.Bounds.Height - test.Height) / 2;
            StandardPopup.IsOpen = true;

        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                add.IsEnabled = false;
                cancel.IsEnabled = false;
                int amount;
                int.TryParse(TxtAmount.Text, out amount);
                Debug.WriteLine(amount);
                dc.addPackingItem(new PackingItem { Name = TxtItem.Text, Amount = amount });
                TxtItem.Text = "";
                TxtAmount.Text = "";
                StandardPopup.IsOpen = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally {
                add.IsEnabled = true;
                cancel.IsEnabled = true;
            }
        }

        private void CheckBoxComplete_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            PackingItem item = cb.DataContext as PackingItem;
            dc.updatePackingItem(item);
            Debug.WriteLine(item.Packed);
        }
        private async void OnBackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            e.Handled = true;
            // add your own code here to run when Back is pressed
            if (StandardPopup.IsOpen)
            {
                StandardPopup.IsOpen = false;
            }
            else
            {
                HardwareButtons.BackPressed -= OnBackPressed;
                Frame.Navigate(typeof(CategorieList));
            }
        }
    }
}
