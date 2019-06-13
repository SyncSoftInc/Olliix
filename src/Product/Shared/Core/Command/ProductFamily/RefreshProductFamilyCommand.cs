namespace SyncSoft.Olliix.Product.Command.ProductFamily
{
    public class RefreshProductFamilyCommand : SyncSoft.App.Messaging.AsyncRequest
    {
        public string FamilyID { get; set; }
    }
}
