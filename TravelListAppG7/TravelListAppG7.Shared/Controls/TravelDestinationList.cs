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
            Frame.Navigate(typeof(CategorieList));
        }
        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            // if the Popup is open, then close it
            TxtDestination.Text = "";
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
            add.IsEnabled=false;
            cancel.IsEnabled = false;
            TravelList travelList = new TravelList { Destination = TxtDestination.Text,Day=DatePicker.Date.DateTime };
            dc.addTravelDestination(travelList);
            TxtDestination.Text = "";
            add.IsEnabled = true;
            cancel.IsEnabled = true;
            StandardPopup.IsOpen = false;
        }
    }
}
