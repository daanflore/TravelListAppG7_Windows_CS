using Windows.UI.Xaml.Controls;
using TravelListAppG7.Domain;
using Windows.UI.Xaml;
using TravelListAppG7.DataModel;
using Windows.UI.Xaml.Data;
using Windows.Phone.UI.Input;

namespace TravelListAppG7.Controls
{
    sealed partial class HomePage : Page
    {

        private DomainController dc;
        private User user;
        public HomePage()
        {
            this.InitializeComponent();
            dc = DomainController.Instance;
            HardwareButtons.BackPressed += OnBackPressed;
            user = dc.user;
            Title.Text = user.Username;
            
        }
        private void ButtonViewDestinations_Click(object sender, RoutedEventArgs e)
        {
            HardwareButtons.BackPressed -= OnBackPressed;
            Frame.Navigate(typeof(TravelDestinationList));
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            HardwareButtons.BackPressed -= OnBackPressed;
            Frame.Navigate(typeof(MainPage));
            dc.user = null;
        }
        private async void OnBackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            HardwareButtons.BackPressed -= OnBackPressed;
            Frame.Navigate(typeof(MainPage));
            dc.user = null;
        }

    }
}
