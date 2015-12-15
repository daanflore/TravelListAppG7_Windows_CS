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
using System.Threading.Tasks;

namespace TravelListAppG7.Controls
{
    sealed partial class TravelDestinationList : Page
    {
        private DomainController dc;
        private int startXCord;
        private int endXCord;
        public TravelDestinationList()
        {
            dc = DomainController.Instance;
            this.InitializeComponent();
            HardwareButtons.BackPressed += OnBackPressed;
            fillContext();
        }
        public async void fillContext()
        {

            this.DataContext = new CollectionViewSource { Source = await dc.GetUserDestinations() };
        }

        private async void ListBox_Tapped(object sender, TappedRoutedEventArgs e)
        {

            //Avoid Access Violation Exception error in visual studio https://social.msdn.microsoft.com/forums/windowsapps/en-us/fde433e8-87f8-4005-ac81-01b12e016986/debugging-access-violation-exceptions
            await Task.Delay(50);
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
                if (DatePicker.Date.Date < DateTime.Now.Date)
                {
                    throw new ArgumentException("If you aren't a time traveler I think it is impossible to travel in the past");
                }
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
            finally
            {
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
 private async  void StackPanel_Holding(object sender, HoldingRoutedEventArgs e)
    {
            try
            {
                TravelList dest = (TravelList)((FrameworkElement)sender).DataContext;
                if (dest != null)
                {
                    MessageDialog messageDialog = new MessageDialog("Are you sure you want To delete " + dest.Destination + " ?");
                    messageDialog.Commands.Add(new UICommand("Delete"));
                    messageDialog.Commands.Add(new UICommand("Cancel"));
                    messageDialog.DefaultCommandIndex = 0;
                    messageDialog.CancelCommandIndex = 1;
                    var result = await messageDialog.ShowAsync();
                    if (result.Label.Equals("Delete"))
                    {
                        dc.removeTravelList(dest);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
   
}


