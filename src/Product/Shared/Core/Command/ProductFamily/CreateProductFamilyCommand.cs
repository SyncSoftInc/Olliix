namespace SyncSoft.Olliix.Product.Command.ProductFamily
{
    public class CreateProductFamilyCommand : SyncSoft.App.Messaging.RequestCommand
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Room { get; set; }
    }
}
