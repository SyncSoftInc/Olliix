using CoreGraphics;
using SyncSoft.App.Components;
using SyncSoft.App.Logging;
using SyncSoft.App.Mvvm;
using SyncSoft.Olliix.Components;
using System;
using System.Threading.Tasks;
using UIKit;
using WebKit;
using Xamarin.Forms;

namespace SyncSoft.Olliix.iOS
{
    internal class iOSPlatformService : IPlatformService
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<ILogger> _lazyLogger = ObjectContainer.LazyResolveLogger<iOSPlatformService>();
        private static ILogger Logger => _lazyLogger.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Field(s)  -

        private static WKWebView _webview;

        #endregion
        // *******************************************************************************************************************************
        #region -  Print  -

        public Task Print(string purpose, string id)
        {
            try
            {
                var printer = UIPrintInteractionController.SharedPrintController;

                printer.ShowsPageRange = true;

                printer.PrintInfo = UIPrintInfo.PrintInfo;
                printer.PrintInfo.OutputType = UIPrintInfoOutputType.General;
                printer.PrintInfo.JobName = id;

                printer.PrintPageRenderer = new UIPrintPageRenderer()
                {
                    HeaderHeight = 40,
                    FooterHeight = 40
                };
                printer.PrintPageRenderer.AddPrintFormatter(_webview.ViewPrintFormatter, 0);

                if (Device.Idiom == TargetIdiom.Phone)
                {
                    printer.PresentAsync(true);
                }
                else if (Device.Idiom == TargetIdiom.Tablet)
                {
                    printer.PresentFromRectInViewAsync(new CGRect(200, 200, 0, 0), _webview, true);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.GetRootExceptionMessage());
            }

            return Task.CompletedTask;
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Init  -

        internal static void Init(WKWebView webview)
        {
            _webview = webview;
        }

        #endregion
    }
}