using Windows.UI.Xaml.Controls;
using TravelListAppG7.Domain;
using Windows.UI.Xaml.Data;

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
                
    }
}
