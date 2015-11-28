using Windows.UI.Xaml.Controls;
using TravelListAppG7.Domain;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using TravelListAppG7.DataModel;
using Windows.UI.Xaml;
using System.Diagnostics;

namespace TravelListAppG7.Controls
{
    sealed partial class TravelDestinationList : Page
    {

        private DomainController dc;
        public TravelDestinationList()
        {
            this.InitializeComponent();
            dc = DomainController.Instance;
            fillContext();
        }
        public async void fillContext() {
            
            this.DataContext = new CollectionViewSource { Source = await dc.GetUserDestinations() };
        }

        private void ListBox_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            TravelList selected = DestinationList.SelectedItem as TravelList;
            dc.destination = selected;
        }
        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            // if the Popup is open, then close it 
            StandardPopup.HorizontalOffset = (Window.Current.Bounds.Width - test.ActualWidth) / 2;
            StandardPopup.VerticalOffset = (Window.Current.Bounds.Height - test.ActualHeight) / 2;
            StandardPopup.IsOpen = false;
        }

        // Handles the Click event on the Button on the page and opens the Popup. 
        private void ShowPopupOffsetClicked(object sender, RoutedEventArgs e)
        {
            test.Width = Window.Current.Bounds.Width / 100 * 80;
            test.Height = Window.Current.Bounds.Height / 100 * 80;
            StandardPopup.HorizontalOffset = (Window.Current.Bounds.Width - test.Width) / 2;
            StandardPopup.VerticalOffset = (Window.Current.Bounds.Height - test.Height) / 2;
            StandardPopup.IsOpen = true;

        }

    }
}
