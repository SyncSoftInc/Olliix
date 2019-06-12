using System;

namespace SyncSoft.Olliix.Product.Enum
{
    [Flags]
    public enum ProductFlagsEnum : int
    {
        HasChanges = 1 << 0,    // [TRG_ProductItems]
        Inactive = 1 << 1,      // [V_ProductItems]
        Clearance = 1 << 2,
        Special = 1 << 3,
    }
}
