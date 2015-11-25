using Windows.UI.Xaml.Controls;
using TravelListAppG7.Domain;

namespace TravelListAppG7.Controls
{
    sealed partial class TravelDestinationList : Page
    {

        private DomainController dc;
        public TravelDestinationList()
        {
            this.InitializeComponent();
            dc = DomainController.Instance;
        }
                
    }
}
