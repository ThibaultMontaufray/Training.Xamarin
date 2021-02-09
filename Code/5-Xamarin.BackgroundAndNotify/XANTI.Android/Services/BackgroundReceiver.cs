using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace XANTI.Droid.Services
{
    [BroadcastReceiver]
    public class BackgroundReceiver : BroadcastReceiver
    {
        private bool _isRunning;
        private Timer _timer;
        private int _count;

        public override void OnReceive(Context context, Intent intent)
        {
            PowerManager pm = (PowerManager)context.GetSystemService(Context.PowerService);
            PowerManager.WakeLock wakeLock = pm.NewWakeLock(WakeLockFlags.Partial, "BackgroundReceiver");
            wakeLock.Acquire();

            Init();
            LaunchServiceAction();

            wakeLock.Release();
        }
        private void Init()
        {
            _count = 0;

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;
        }
        private void LaunchServiceAction()
        {
            _timer.Start();
        }
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            MessagingCenter.Send<object, string>(this, "UpdateLabelBackground", String.Format("Application started. The count is about {1}", DateTime.Now, _count));
            _count++;
            _timer.Start();
        }
    }
}