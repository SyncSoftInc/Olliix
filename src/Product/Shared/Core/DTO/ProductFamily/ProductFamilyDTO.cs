using SyncSoft.Olliix.Product.DTO.ProductItem;
using SyncSoft.Olliix.Product.Enum;
using System.Collections.Generic;

namespace SyncSoft.Olliix.Product.DTO.ProductFamily
{
    public class ProductFamilyDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Room { get; set; }

        public ProductFlagsEnum? Flags { get; set; }
        public IList<ProductItemDTO> Items { get; set; } = new List<ProductItemDTO>();
    }
}
