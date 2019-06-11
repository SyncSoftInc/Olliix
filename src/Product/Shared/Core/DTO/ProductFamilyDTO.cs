using SyncSoft.Olliix.Product.Enum;
using System.Collections.Generic;

namespace SyncSoft.Olliix.Product.DTO
{
    public class ProductFamilyDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }

        public ProductFlagsEnum? Flags { get; set; }
        public IList<ProductItemDTO> Items { get; set; }
    }
}
