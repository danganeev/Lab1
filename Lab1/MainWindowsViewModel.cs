using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class MainWindowsViewModel
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate
        {
            get { return _EventDate; }
            set { _EventDate = value;
            }
        }

        private DateTime _EventDate = DateTime.Now;
        public string EventLocation { get; set; }

        private bool? _Notification;
        public bool? Notification
        {
            get { return (_Notification != null) ? _Notification : false; }
            set { _Notification = value;
            }

        }


        public UInt32 NotificationTime { get; set; }
        public List<String> TimeFrames { get; set; }
        public string SelectedTimeFrame { get; set; }

        private bool? _Repeated;
        public bool? Repeated
        {
            get { return (_Repeated != null) ? _Repeated : false; }
            set
            {
                _Repeated = value;
            }

        }

        public MainWindowsViewModel()
        {
            TimeFrames = new List<string>()
            {
                "минут",
                "часов",
                "дней"
            };
            SelectedTimeFrame = TimeFrames[0];
        }


    }
}
