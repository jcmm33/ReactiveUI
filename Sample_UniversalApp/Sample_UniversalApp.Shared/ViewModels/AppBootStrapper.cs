using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using ReactiveUI;
using ReactiveUI.Mobile;
using Sample_UniversalApp.Views;
using Splat;

namespace Sample_UniversalApp.ViewModels
{
    [DataContract]
    public class AppBootstrapper : ReactiveObject, IApplicationRootState
    {
        [DataMember]
        RoutingState router;

        public RoutingState Router
        {
            get { return router; }
            set { router = value; }
        }

        public AppBootstrapper()
        {
            Router = new RoutingState();

            var resolver = Locator.CurrentMutable;

            resolver.Register(() => new FirstView(), typeof(IViewFor<FirstView>), "FullScreenLandscape");

            resolver.RegisterConstant(this, typeof(IApplicationRootState));
            resolver.RegisterConstant(this, typeof(IScreen));
            resolver.RegisterConstant(new MainPage(), typeof(IViewFor), "InitialPage");

            Router.Navigate.Execute(new FirstViewModel(this){Username = "BOUND USERNAME"});
        }
    }
}
