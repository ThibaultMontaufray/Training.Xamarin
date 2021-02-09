﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using Xamarin.Forms;
using XANTI.iOS.Services;

namespace XANTI.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private PeriodicService service;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            WireUpPeriodicService();

            return base.FinishedLaunching(app, options);
        }

        private void WireUpPeriodicService()
        {
            service = new PeriodicService();

            MessagingCenter.Subscribe<object, string>(this, "ServiceAction", (s, e) => {
                if (e.Equals("start"))
                {
                    service.Start(36);
                }
                else
                {
                    service.Stop();
                }
            });
        }
    }
}
