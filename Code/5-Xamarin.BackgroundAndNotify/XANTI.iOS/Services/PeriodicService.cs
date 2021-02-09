using System;
using TIMER = System.Timers;
using System.Threading;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

namespace XANTI.iOS.Services
{
    public class PeriodicService
    {
        private int _taskId;
        private bool _isRunning;
        private TIMER.Timer _timer;
        private int _count;

        //private nint _taskId;
        //private CancellationTokenSource _cts;

        public void Start(int taskId)
        {
            Init();

            //var descInt = intent?.GetIntExtra("actionId", 0);
            //desc = descInt.GetValueOrDefault().ToString();

            _taskId = taskId;
            _isRunning = true;
            _timer.Start();


            //_cts = new CancellationTokenSource();
            //_taskId = UIApplication.SharedApplication.BeginBackgroundTask("LongRunningTask", OnExpiration);

            //try
            //{
            //    var descInt = intent?.GetIntExtra("actionId", 0);
            //
            //    var counter = new LaunchTask();
            //    await counter.RunCounter(_cts.Token);
            //}
            //catch (OperationCanceledException)
            //{
            //}
            //finally
            //{
            //    if (_cts.IsCancellationRequested)
            //    {
            //        var message = "cancelled !";
            //        Device.BeginInvokeOnMainThread(() => MessagingCenter.Send(message, "CancelledMessage"));
            //    }
            //}

            //UIApplication.SharedApplication.EndBackgroundTask(_taskId);
        }
        public void Stop()
        {
            _isRunning = false;
            _timer.Stop();

            //_cts.Cancel();
        }
        public void OnExpiration()
        {
            _isRunning = false;
            _timer.Stop();

            //_cts.Cancel();
        }

        private void Init()
        {
            _count = 0;

            _timer = new TIMER.Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, TIMER.ElapsedEventArgs e)
        {
            _timer.Stop();
            MessagingCenter.Send<object, string>(this, "UpdateLabelService", String.Format("At {0} the count is about {1} with action {2}", DateTime.Now, _count, _taskId));
            _count++;
            if (_isRunning) { _timer.Start(); }
        }
    }
}
