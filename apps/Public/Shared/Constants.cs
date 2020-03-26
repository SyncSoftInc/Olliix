namespace SyncSoft.Olliix
{
    public static class Constants
    {
        public static class NAV
        {
            public const string WebApp = nameof(WebApp);
        }

        public static class URL
        {
#if DEBUG
            public const string DEFAULT_WEBAPP = "https://dt.olliix.com";
#elif TEST
            public const string DEFAULT_WEBAPP = "https://tw.olliix.com";
#else
            public const string DEFAULT_WEBAPP = "https://www.olliix.com";
#endif
        }
    }
}
