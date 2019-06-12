namespace SyncSoft.Olliix.Product.Command.Catalogue
{
    public class GenerateCatalogueItemCommand : SyncSoft.App.Messaging.RequestCommand
    {
        public string FamilyID { get; set; }
    }
}
