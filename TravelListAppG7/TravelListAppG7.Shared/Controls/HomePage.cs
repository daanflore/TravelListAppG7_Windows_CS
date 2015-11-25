using Windows.UI.Xaml.Controls;
using TravelListAppG7.Domain;
using Windows.UI.Xaml;
using TravelListAppG7.DataModel;
using Windows.UI.Xaml.Data;

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
            user = dc.user;
            Title.Text = user.Username;
            
        }
        private void ButtonViewDestinations_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TravelDestinationList));
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
            dc.user = null;
        }

    }
}
