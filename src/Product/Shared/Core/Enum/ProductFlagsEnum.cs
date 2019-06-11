using System;

namespace SyncSoft.Olliix.Product.Enum
{
    [Flags]
    public enum ProductFlagsEnum : int
    {
        HasChanges = 1 << 0,    // [TRG_ProductItems]
        Special = 1 << 1,
        Clearance = 1 << 2,
        Inactive = 1 << 3,
    }
}
