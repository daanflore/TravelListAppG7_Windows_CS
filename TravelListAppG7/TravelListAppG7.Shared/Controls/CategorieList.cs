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
    public sealed partial class CategorieList : Page
    {
        private DomainController dc;
        private int startXCord;
        private int endXCord;
        public CategorieList()
        {
            dc = DomainController.Instance;
            this.InitializeComponent();
            CategorieDetailList.ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY;
            HardwareButtons.BackPressed += OnBackPressed;
            fillContext();
        }

        public async void fillContext()
        {
            var c = await dc.getTravelListPacking();
            this.DataContext = new CollectionViewSource { Source = await dc.GetTravelListCategorie() };
        }
        private async void ListBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await Task.Delay(50);
            Categorie selected = CategorieDetailList.SelectedItem as Categorie;
            dc.categorie = selected;
            HardwareButtons.BackPressed -= OnBackPressed;
            Frame.Navigate(typeof(PackingList));
        }
        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            // if the Popup is open, then close it
            TxtCategorie.Text = "";
            StandardPopup.IsOpen = false;
        }

        // Handles the Click event on the Button on the page and opens the Popup. 
        private void ShowPopupOffsetClicked(object sender, RoutedEventArgs e)
        {
            PopupGrid.Width = Window.Current.Bounds.Width;
            PopupGrid.Height = Window.Current.Bounds.Height;
            StandardPopup.HorizontalOffset = (Window.Current.Bounds.Width - PopupGrid.Width) / 2;
            StandardPopup.VerticalOffset = (Window.Current.Bounds.Height - PopupGrid.Height) / 2;
            StandardPopup.IsOpen = true;

        }
        private async void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                add.IsEnabled = false;
                cancel.IsEnabled = false;
                dc.addCategorie(new Categorie { Name = TxtCategorie.Text });

                StandardPopup.IsOpen = false;
            }
            catch (ArgumentException ex)
            {
                MessageDialog msgbox = new MessageDialog(ex.Message);
                await msgbox.ShowAsync();
            }
            finally
            {
                TxtCategorie.Text = "";
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
                Frame.Navigate(typeof(TravelDestinationList));
            }
        }
        private async void StackPanel_Holding(object sender, HoldingRoutedEventArgs e)
        {
            try
            {
                Categorie cat = (Categorie)((FrameworkElement)sender).DataContext;
                if (cat != null)
                {
                    MessageDialog messageDialog = new MessageDialog("Are you sure you want To delete " + cat.Name + " ?");
                    messageDialog.Commands.Add(new UICommand("Delete"));
                    messageDialog.Commands.Add(new UICommand("Cancel"));
                    messageDialog.DefaultCommandIndex = 0;
                    messageDialog.CancelCommandIndex = 1;
                    var result = await messageDialog.ShowAsync();
                    if (result.Label.Equals("Delete"))
                    {
                        dc.removeCategorie(cat);
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
    }
}
