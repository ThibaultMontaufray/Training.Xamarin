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
    [Service]
    public class PeriodicService : Service
    {
        private string desc;
        private bool _isRunning;
        private Timer _timer;
        private int _count;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Init();

            var descInt = intent?.GetIntExtra("actionId", 0);
            desc = descInt.GetValueOrDefault().ToString();

            _isRunning = true;
            _timer.Start();

            return StartCommandResult.NotSticky;
        }
        public override void OnDestroy()
         {
            _isRunning = false;
            _timer.Stop();

            base.OnDestroy();
        }

        private void Init()
        {
            _count = 0;

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;
        }
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            MessagingCenter.Send<object, string>(this, "UpdateLabelService", String.Format("At {0} the count is about {1} with action {2}", DateTime.Now, _count, desc));
            _count++;
            if (_isRunning) { _timer.Start(); }
        }
    }
}