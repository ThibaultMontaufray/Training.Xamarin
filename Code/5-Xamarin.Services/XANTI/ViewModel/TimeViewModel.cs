using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Timers;
using XANTI.Model;

namespace XANTI.ViewModel
{
    public class TimeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Time Data { get; set; }
        private Timer _timer;

        public string Current
        {
            get
            {
                if (Data != null)
                {
                    TimeSpan span = (DateTime.Now - Data.Current);
                    return String.Format("{0}:{1}", span.Minutes, span.Seconds);
                }
                else
                {
                    return "No data";
                }
            }
        }

        protected virtual new void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TimeViewModel()
        {
            Data = new Time();
            Data.Current = DateTime.Now;

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            OnPropertyChanged("Current");
            _timer.Start();
        }
    }
}
