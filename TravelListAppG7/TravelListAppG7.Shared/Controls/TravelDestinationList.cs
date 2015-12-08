using Windows.UI.Xaml.Controls;
using TravelListAppG7.Domain;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using TravelListAppG7.DataModel;
using Windows.UI.Xaml;
using System.Diagnostics;
using Windows.Phone.UI.Input;
using System;
using Windows.UI.Popups;
using System.ComponentModel;
using Windows.UI.Input;
using System.Collections.Generic;
using Windows.Foundation;

namespace TravelListAppG7.Controls
{
    sealed partial class TravelDestinationList : Page
    {
        private Point initialpoint;
        private int teller = 0;
        private DomainController dc;
        public TravelDestinationList()
        {
            dc = DomainController.Instance;
            this.InitializeComponent();
            HardwareButtons.BackPressed += OnBackPressed;
            
            fillContext();
        }
        public async void fillContext() {
            
            this.DataContext = new CollectionViewSource { Source = await dc.GetUserDestinations() };
        }

        private void ListBox_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            TravelList selected = DestinationList.SelectedItem as TravelList;
            dc.destination = selected;
            HardwareButtons.BackPressed -= OnBackPressed;
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
            PopupGrid.Width = Window.Current.Bounds.Width;
            PopupGrid.Height = Window.Current.Bounds.Height;
            StandardPopup.HorizontalOffset = (Window.Current.Bounds.Width - Window.Current.Bounds.Width) / 2;
            StandardPopup.VerticalOffset = (Window.Current.Bounds.Height - Window.Current.Bounds.Height) / 2;
            StandardPopup.IsOpen = true;

        }
        private async void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                add.IsEnabled = false;
                cancel.IsEnabled = false;
                TravelList travelList = new TravelList { Destination = TxtDestination.Text, Day = DatePicker.Date.DateTime };
                dc.addTravelDestination(travelList);
                TxtDestination.Text = "";
                StandardPopup.IsOpen = false;
            }
            catch (ArgumentException ex)
            {
                MessageDialog msgbox = new MessageDialog(ex.Message);
                await msgbox.ShowAsync();
            }
            finally {
                add.IsEnabled = true;
                cancel.IsEnabled = true;
            }
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
                Frame.Navigate(typeof(HomePage));
            }
        }
        private void DestinationList_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            initialpoint = e.Position;
            Debug.WriteLine("manipulation started");
        }

        private void DestinationList_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            Debug.WriteLine("ManipulationDelta");
            if (e.IsInertial)
            {
                Point currentpoint = e.Position;
                if (currentpoint.X - initialpoint.X >= 500)//500 is the threshold value, where you want to trigger the swipe right event
                {
                    Debug.WriteLine("Swipe Right");
                    e.Complete();
                }
            }
        }
        private void StackPanel_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Debug.WriteLine("click");
        }
        private void StackPanel_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Debug.WriteLine("Releades");
        }




    }

}
