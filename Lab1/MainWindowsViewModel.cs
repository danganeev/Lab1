using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab1
{
    //public class MainWindowsViewModel: INotifyPropertyChanged
    public class MainWindowsViewModel: INotifyPropertyChanged
    {
        private string _EventName;
        public string EventName { get { return _EventName; } set {_EventName=value; DoPropertyChanged("EventName"); } }

        private string _EventDescription;
        public string EventDescription { get { return _EventDescription; } set { _EventDescription = value; DoPropertyChanged("EventDescription"); } }

        public static DateTime EventDate
        {
            get { return _EventDate.Date; }
            set { _EventDate = value.Date + _EventDate.TimeOfDay;
            }
        }
        public static DateTime EventTime
        {
            get { return _EventDate; }
            set
            {
                _EventDate = _EventDate.Date + value.TimeOfDay;
            }
        }

        private static DateTime _EventDate = DateTime.Now;

        private string _EventLocation;
        public string EventLocation { get { return _EventLocation; } set { _EventLocation = value; DoPropertyChanged("EventLocation"); } }

        private bool? _Notification;
        public bool? Notification
        {
            get { return (_Notification != null) ? _Notification : false; }
            set { _Notification = value; DoPropertyChanged("Notification");
            }

        }

        private UInt32 _NotificationTime;
        public UInt32 NotificationTime { get { return _NotificationTime; } set { _NotificationTime = value; DoPropertyChanged("NotificationTime"); } }

        public List<String> TimeFrames { get; set; }
        public static string SelectedTimeFrame { get; set; }

        private bool? _Repeated;
        public bool? Repeated
        {
            get { return (_Repeated != null) ? _Repeated : false; }
            set
            {
                _Repeated = value;
            }

        }

        public ICommand Save { get; set; } 
        public ICommand Cancel { get; set; }


        public MainWindowsViewModel()
        {
            TimeFrames = new List<string>()
            {
                "минут",
                "часов",
                "дней"
            };
            SelectedTimeFrame = TimeFrames[0];
            Save = new ButtonCommand();
            Cancel = new ButtonCommand();

        }

        public event PropertyChangedEventHandler PropertyChanged; 
        public void DoPropertyChanged(String name)
        { 
            if (PropertyChanged != null) 
            { 
                PropertyChanged(this, new PropertyChangedEventArgs(name)); 
            } 
        } 



    }
}
