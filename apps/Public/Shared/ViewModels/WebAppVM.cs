using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncSoft.Olliix.ViewModels
{
    public class WebAppVM : ViewModelBase
    {
        // *******************************************************************************************************************************
        #region -  Field(s)  -

        public event EventHandler Refreshing;

        #endregion
        // *******************************************************************************************************************************
        #region -  Property(ies)  -

        private string _TargetUrl;
        public string TargetUrl
        {
            get { return _TargetUrl; }
            set
            {
                if (value != _TargetUrl)
                {
                    _TargetUrl = value;
                    RaisePropertyChanged(nameof(TargetUrl));
                }
            }
        }

#if DEBUG
        private bool _IsDebug = true;
#else
        private bool _IsDebug = false;
#endif
        public bool IsDebug
        {
            get { return _IsDebug; }
            set
            {
                if (value != _IsDebug)
                {
                    _IsDebug = value;
                    RaisePropertyChanged(nameof(IsDebug));
                }
            }
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Constructor(s)  -

        public WebAppVM()
        {
            TargetUrl = Constants.URL.DEFAULT_WEBAPP + $"?r={DateTime.Now.Ticks}";
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Commands  -

        public ICommand SetBusyCommand
        {
            get
            {
                return new Command((arg) =>
                {
                    if (bool.TryParse(arg?.ToString(), out bool isBusy)) IsBusy = isBusy;
                }, arg => arg.IsNotNull());
            }
        }

        public ICommand SetDebugCommand
        {
            get
            {
                return new Command((arg) =>
                {
                    if (bool.TryParse(arg?.ToString(), out bool isDebug)) IsDebug = isDebug;
                }, arg => arg.IsNotNull());
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsBusy = true;
                    Refreshing?.Invoke(this, EventArgs.Empty);
                });
            }
        }

        #endregion
    }
}
