using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XANTI.Services;

namespace XANTI.Droid.Services
{
    public class CrossPlatform : ICrossPlatform
    {
        private Intent intent;
        public void StartTask(int actionId)
        {
            intent = new Intent(Android.App.Application.Context, typeof(PeriodicService));
            intent.PutExtra("actionId", actionId);
            Android.App.Application.Context.StartService(intent);
        }

        public void StopTask()
        {
            Android.App.Application.Context.StopService(intent);
        }
    }
}