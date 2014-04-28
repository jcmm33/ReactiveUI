using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using Splat;

namespace Sample_UniversalApp.ViewModels
{
    public class FirstViewModel : ReactiveObject, IRoutableViewModel
    {
        private string username = String.Empty;
        public string Username
        {
            get { return username; }
            set { this.RaiseAndSetIfChanged(ref username, value); }
        }


        public string UrlPathSegment { get { return "Login"; } }
        public IScreen HostScreen { get; private set; }

        public FirstViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        }
    }
}
