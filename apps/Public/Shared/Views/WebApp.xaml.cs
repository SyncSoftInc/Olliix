using SyncSoft.App.Components;
using SyncSoft.App.Logging;
using SyncSoft.ECP.Mobile.UI;
using SyncSoft.Olliix.Components;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using Xamarin.Essentials;
using SyncSoft.App.Json;

namespace SyncSoft.Olliix.Views
{

    public partial class WebApp : ContentPage
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<ILogger> _lazyLogger = ObjectContainer.LazyResolveLogger<WebApp>();
        private ILogger _Logger => _lazyLogger.Value;

        private static readonly Lazy<IPlatformService> _lazyPlatformService = ObjectContainer.LazyResolve<IPlatformService>();
        private IPlatformService _PlatformService => _lazyPlatformService.Value;

        private static readonly Lazy<IJsonSerializer> _lazyJsonSerializer = ObjectContainer.LazyResolve<IJsonSerializer>();
        private IJsonSerializer JsonSerializer => _lazyJsonSerializer.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Constructor(s)  -

        public WebApp()
        {
            // 绑定上下文
            BindingContext = VMLocator.WebApp;
            VMLocator.WebApp.Refreshing += WebApp_Refreshing;

            // 初始化组件
            InitializeComponent();

            // 浏览器事件
            //MainWebView.OnNavigationStarted += MainWebView_OnNavigationStarted; ;
            MainWebView.OnContentLoaded += MainWebView_OnContentLoaded;
            //MainWebView.OnNavigationError += MainWebView_OnNavigationError;

            // 注册允许JS调用的内嵌命令
            MainWebView.AddLocalCallback("native", RegisterLocalCallback);

            // 初次加载，显示等待遮罩
            VMLocator.WebApp.SetBusyCommand.Execute(true);
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  RegisterLocalCallback  -

        private async void RegisterLocalCallback(string args)
        {
            var arrays = args.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (arrays.Length > 0)
            {
                var cmd = arrays[0];

                switch (cmd)
                {
                    case "Scan":
                        await ScanBarcodeCommandHandler(arrays);
                        break;
                    case "Refresh":
                        await RefreshCommandHandler(arrays);
                        break;
                    case "Print":
                        await PrintCommandHandler(arrays);
                        break;
                    case "Location":
                        await LocationCommandHandler(arrays);
                        break;
                    case "SetBusy":
                        await SetBusyCommandHandler(arrays);
                        break;
                    case "SetDebug":
                        await SetDebugCommandHandler(arrays);
                        break;
                }
            }
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Events  -

        //private void MainWebView_OnNavigationStarted(object sender, Xam.Plugin.WebView.Abstractions.Delegates.DecisionHandlerDelegate e)
        //{
        //    VMLocator.WebApp.SetBusyCommand.Execute(true);
        //}

        //private void MainWebView_OnNavigationError(object sender, int e)
        //{
        //    VMLocator.WebApp.SetBusyCommand.Execute(false);
        //}

        private void MainWebView_OnContentLoaded(object sender, EventArgs e)
        {
            VMLocator.WebApp.SetBusyCommand.Execute(false);
        }

        private async void WebApp_Refreshing(object sender, EventArgs e)
        {
            try
            {
                //VMLocator.WebApp.TargetUrl = Constants.URL.DEFAULT_WEBAPP + $"?r={DateTime.Now.Ticks}";
                MainWebView.Refresh();
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex, "Refresh failed.");
            }
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  ScanBarcodeCommandHandler  -

        private async Task ScanBarcodeCommandHandler(string[] args)
        {
            try
            {
                var scanPage = new ZXingScannerPage();
                scanPage.OnScanResult += (result) =>
                {
                    scanPage.IsScanning = false;
                    Device.BeginInvokeOnMainThread(async () => await Navigation.PopModalAsync());

                    var barcode = result.Text;
                    if (barcode.IsPresent())
                    {
                        var purpose = args.Length > 1 ? args[1] : null;

                        var js = $"ScanCallback('{purpose}', '{barcode}')";
                        Device.BeginInvokeOnMainThread(async () => await MainWebView.InjectJavascriptAsync(js));
                    }
                };

                var toolbarItem = new ToolbarItem { Text = "Cancel" };
                toolbarItem.Clicked += (s, e) =>
                {
                    scanPage.IsScanning = false;
                    Device.BeginInvokeOnMainThread(async () => await Navigation.PopModalAsync());
                };

                var navPage = new NavigationPage(scanPage);
                navPage.ToolbarItems.Add(toolbarItem);

                Device.BeginInvokeOnMainThread(async () => await Navigation.PushModalAsync(navPage));
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex, "Scan failed.");
            }
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  RefreshCommandHandler  -

        private Task RefreshCommandHandler(string[] args)
        {
            VMLocator.WebApp.RefreshCommand.Execute(null);
            return Task.CompletedTask;
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  PrintCommandHandler  -

        private async Task PrintCommandHandler(string[] args)
        {
            if (args.Length > 2)
            {
                VMLocator.WebApp.SetBusyCommand.Execute(true);
                await _PlatformService.Print(args[1], args[2]);
                VMLocator.WebApp.SetBusyCommand.Execute(false);
            }
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  SetBusyCommandHandler  -

        private Task SetBusyCommandHandler(string[] args)
        {
            var purpose = args.Length > 1 ? args[1] : null;
            VMLocator.WebApp.SetBusyCommand.Execute(purpose == "true");

            return Task.CompletedTask;
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  SetDebugCommandHandler  -

        private Task SetDebugCommandHandler(string[] args)
        {
            var purpose = args.Length > 1 ? args[1] : null;
            VMLocator.WebApp.SetDebugCommand.Execute(purpose == "true");

            return Task.CompletedTask;
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  LocationCommandHandler  -

        private async Task LocationCommandHandler(string[] args)
        {
            Location location;
            try
            {
                location = await Geolocation.GetLastKnownLocationAsync();
            }
            catch (Exception ex)
            {
                location = new Location();
                await HandleErrorAsync(ex, "Get location failed.");
            }

            var js = "LocationCallback(" + JsonSerializer.Serialize(location ?? new Location()) + ")";
            Device.BeginInvokeOnMainThread(async () => await MainWebView.InjectJavascriptAsync(js));
        }

        #endregion

        // *******************************************************************************************************************************
        #region -  HandleError  -

        private async Task HandleErrorAsync(Exception ex, string message)
        {
            await DisplayAlert("Error", message + "\n" + ex.GetRootExceptionMessage(), "Cancel");
            _Logger.Error(ex, ex.GetRootExceptionMessage());
        }

        #endregion
    }
}