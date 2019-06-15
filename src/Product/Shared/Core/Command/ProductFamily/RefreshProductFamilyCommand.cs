using System.Collections.Generic;

namespace SyncSoft.Olliix.Product.Command.ProductFamily
{
    public class RefreshProductFamilyCommand : SyncSoft.App.Messaging.AsyncRequest
    {
        public IList<string> FamilyIDs { get; set; }
        public bool RefreshAll { get; set; }
        public bool RefreshChangesOnly { get; set; }
    }
}
