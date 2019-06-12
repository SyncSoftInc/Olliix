namespace SyncSoft.Olliix
{
    internal static class TestUtils
    {
        public const string Family_IdPrefix = "FAMILY";
        public const string Item_IdPrefix = "ITEM";

        public static string CreateFamilyID(int i)
        {
            return $"{Family_IdPrefix}{i:D3}";
        }

        //public static string CreateItemNo(int i)
        //{
        //    return $"{Item_IdPrefix}{i:D3}";
        //}

        public static string CreateItemNo(string familyId, int itemId)
        {
            return $"{familyId}:{Item_IdPrefix}{itemId:D3}";
        }
    }
}
