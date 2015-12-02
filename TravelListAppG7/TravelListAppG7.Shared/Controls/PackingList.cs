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
            fillContext();
        }

        public async void fillContext()
        {
            var contextzelf =await dc.GetCategoriePacking();
            this.DataContext = new CollectionViewSource { Source = await dc.GetCategoriePacking() };
        }
        private void ListBox_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            //Categorie selected = CategorieDetailList.SelectedItem as Categorie;
            //dc.categorie = selected;
            Frame.Navigate(typeof(CategorieList));
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
            add.IsEnabled = false;
            cancel.IsEnabled = false;
            dc.addPackingItem(new PackingItem { Name = TxtItem.Text });
            TxtItem.Text = "";
            TxtAmount.Text = "";
            add.IsEnabled = true;
            cancel.IsEnabled = true;
            StandardPopup.IsOpen = false;
        }

        private void CheckBoxComplete_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            PackingItem item = cb.DataContext as PackingItem;
            dc.updatePackingItem(item);
            Debug.WriteLine(item.Packed);
        }
    }
}
