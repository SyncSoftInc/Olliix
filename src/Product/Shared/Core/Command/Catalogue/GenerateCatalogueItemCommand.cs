namespace SyncSoft.Olliix.Product.Command.Catalogue
{
    public class GenerateCatalogueItemCommand : SyncSoft.App.Messaging.AsyncRequest
    {
        public string FamilyID { get; set; }
    }
}
