using SyncSoft.ECP.Mobile.UI;
using SyncSoft.Olliix.Views;

namespace SyncSoft.Olliix.Components
{
    public class OlliixAppUICoordinator : UICoordinator
    {
        static OlliixAppUICoordinator()
        {
            _Pages.Add(Constants.NAV.WebApp, typeof(WebApp));
        }
    }
}
