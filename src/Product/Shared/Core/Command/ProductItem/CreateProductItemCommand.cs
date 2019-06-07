using SyncSoft.Olliix.Product.Enum;

namespace SyncSoft.Olliix.Product.Command.ProductItem
{
    public class CreateProductItemCommand : SyncSoft.App.Messaging.RequestCommand
    {
        public string Family_ID { get; set; }
        public string ItemNo { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string ImageHash { get; set; }
        public string ImageUrl { get; set; }
        public string UPC { get; set; }
        public string Description { get; set; }
        public string ProductDetails { get; set; }
        public string MaterialDetails { get; set; }
        public string CareInstructions { get; set; }

        public decimal MSRPrice { get; set; }
        public decimal Price { get; set; }

        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }

        public ProductItemStatusEnum Status { get; set; }

        public string[] ExtraImages { get; set; }
    }
}
