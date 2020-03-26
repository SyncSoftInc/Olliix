using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using SyncSoft.App;
using SyncSoft.App.Components;
using SyncSoft.Olliix.Components;
using UIKit;
using Xam.Plugin.WebView.iOS;

namespace SyncSoft.Olliix.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            ////////// 启动引擎
            AppEngine.Init()
                .RegisterComponent<IPlatformService, iOSPlatformService>(LifeCycleEnum.Singleton)
                .UseOlliixAppConfigurations()
                .Start();

            ////////// 初始化浏览器
            FormsWebViewRenderer.Initialize();
            FormsWebViewRenderer.OnControlChanged += FormsWebViewRenderer_OnControlChanged;

            ////////// 初始化扫描器
            ZXing.Net.Mobile.Forms.iOS.Platform.Init();

            // 强制竖屏

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        private void FormsWebViewRenderer_OnControlChanged(object sender, WebKit.WKWebView e)
        {
            iOSPlatformService.Init(e);
        }

        //public bool RestrictRotation = true;
        [Export("application:supportedInterfaceOrientationsForWindow:")]
        public UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, IntPtr forWindow)
        {
            // 强制竖屏
            return UIInterfaceOrientationMask.Portrait;
            //if (this.RestrictRotation)
            //    return UIInterfaceOrientationMask.Portrait;
            //else
            //    return UIInterfaceOrientationMask.AllButUpsideDown;
        }
    }
}
