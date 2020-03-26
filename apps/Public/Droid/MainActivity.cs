using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android;
using Android.Support.V4.Content;
using SyncSoft.App;
using SyncSoft.Olliix.Components;
using SyncSoft.App.Components;
using Xam.Plugin.WebView.Droid;

namespace SyncSoft.Olliix.Droid
{
    [Activity(LaunchMode = LaunchMode.SingleTop, Label = "Olliix", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private const int PERMISSION_REQUEST_ID = 101;

        static MainActivity()
        {
            ////////// 启动引擎
            AppEngine.Init()
                .RegisterComponent<IPlatformService, AndroidPlatformService>(LifeCycleEnum.Singleton)
                .UseOlliixAppConfigurations()
                .Start();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) != Permission.Granted && ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new[] {
                        Manifest.Permission.Camera,
                        Manifest.Permission.AccessCoarseLocation,
                        Manifest.Permission.AccessFineLocation,
                    }, PERMISSION_REQUEST_ID);
                //// Should we show an explanation?
                //if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.Camera))
                //{

                //    // Show an expanation to the user *asynchronously* -- don't block
                //    // this thread waiting for the user's response! After the user
                //    // sees the explanation, try again to request the permission.

                //}
                //else
                //{

                //    // No explanation needed, we can request the permission.

                //    ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.Camera }, MY_PERMISSIONS_REQUEST_Camera);

                //    // MY_PERMISSIONS_REQUEST_Camera is an
                //    // app-defined int constant. The callback method gets the
                //    // result of the request.
                //}
            }
            else if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new[] {
                        Manifest.Permission.Camera,
                    }, PERMISSION_REQUEST_ID);
            }
            else if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new[] {
                         Manifest.Permission.AccessCoarseLocation,
                        Manifest.Permission.AccessFineLocation,
                    }, PERMISSION_REQUEST_ID);
            }

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            ////////// 强制竖屏
            this.RequestedOrientation = ScreenOrientation.Portrait;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            ////////// 初始化扫描器
            ZXing.Mobile.MobileBarcodeScanner.Initialize(Application);
            ZXing.Net.Mobile.Forms.Android.Platform.Init();

            ////////// 初始化浏览器
            FormsWebViewRenderer.Initialize();
            FormsWebViewRenderer.OnControlChanged += FormsWebViewRenderer_OnControlChanged;

            ////////// 初始化对话框组件
            Acr.UserDialogs.UserDialogs.Init(this);

            LoadApplication(new App());
        }

        private void FormsWebViewRenderer_OnControlChanged(object sender, Android.Webkit.WebView webView)
        {
            var printManager = (Android.Print.PrintManager)BaseContext.GetSystemService(PrintService);
            AndroidPlatformService.Init(printManager, webView);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            //base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}