namespace SyncSoft.Olliix.Product.DTO
{
    public class CatalogueItemDTO
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string DetailUrl { get; set; }
        public string BrandUrl { get; set; }
        public string Brand { get; set; }
        public string ItemNo { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }

        public string Search_Categories { get; set; }
        public string Search_Brands { get; set; }
        public string Search_Colors { get; set; }
        public string Search_Rooms { get; set; }
    }
}
