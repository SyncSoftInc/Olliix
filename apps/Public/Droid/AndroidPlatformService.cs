using Android.Print;
using Android.Webkit;
using SyncSoft.App.Components;
using SyncSoft.App.Mvvm;
using SyncSoft.Olliix.Components;
using System;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Droid
{
    internal class AndroidPlatformService : IPlatformService
    {
        // *******************************************************************************************************************************
        #region -  Field(s)  -

        private static PrintManager _printManager;
        private static WebView _webView;

        #endregion
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IUIDispatcher> _lazyUIDispatcher = ObjectContainer.LazyResolve<IUIDispatcher>();
        private IUIDispatcher _UIDispatcher => _lazyUIDispatcher.Value;

        #endregion

        public Task Print(string purpose, string id)
        {
            _UIDispatcher.Invoke(() =>
            {
                _printManager.Print(purpose, _webView.CreatePrintDocumentAdapter(purpose), null);
            });

            return Task.CompletedTask;
        }

        internal static void Init(PrintManager printMgr, WebView webView)
        {
            _printManager = printMgr;
            _webView = webView;
        }
    }
}