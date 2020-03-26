using SyncSoft.App.Components;
using SyncSoft.ECP.Mobile.UI;
using SyncSoft.Olliix.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SyncSoft.Olliix
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new WebApp();

            // 初始化UI协调器
            ObjectContainer.Resolve<IUICoordinator>().Init(MainPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
