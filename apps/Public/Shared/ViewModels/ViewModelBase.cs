using SyncSoft.ECP.Mobile.ViewModels;
using Xamarin.Forms;

namespace SyncSoft.Olliix.ViewModels
{
    public class ViewModelBase : VMBase
    {
        public double ActivityIndicatorScale => Device.RuntimePlatform == Device.Android ? .1 : 1;   // 解决Android上等待动画太大的问题
    }
}
