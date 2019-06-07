using System;

namespace SyncSoft.Olliix.Product.Enum
{
    [Flags]
    public enum ProductItemStatusEnum : int
    {
        HasChanges = 1 << 0,
        Special = 1 << 1,
        Clearance = 1 << 2,
        Inactive = 1 << 3,
    }
}
