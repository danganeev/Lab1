using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace Lab1
{
    internal class SaveCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //using(SqlConnection cn = new SqlConnection("Server=DESKTOP-JMIH12N\SQLEXPRESS; Database=heroDatabase; Trusted_Connection=True;"))
            //{
            //    SqlCommand cmd = new SqlCommand("INSERT INTO Events(EventName, EventDescription,EventDate, EventTime, EventLocation, ISNotification, TimeBefore, TimeType, ISRepeated) VALUES(@)", cn);
            //} 
            var apply = parameter as MainWindowsViewModel;
            if (String.IsNullOrWhiteSpace(apply.EventName) ||
                String.IsNullOrWhiteSpace(apply.EventDescription) ||
                String.IsNullOrWhiteSpace(apply.EventLocation))
                MessageBox.Show("All field are required!");

            else

            {
                using (SqlConnection cn = new SqlConnection("Server=DESKTOP-JMIH12N\\SQLEXPRESS; Database=heroDatabase; Trusted_Connection=True;"))
                {
                    cn.Open();
                    if (apply.Notification == true)
                    {
                        String query = String.Format("INSERT INTO EventDB(EventName, EventDescription,EventDate, EventTime, EventLocation, ISNotification, TimeBefore, TimeType, ISRepeated) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", apply.EventName, apply.EventDescription, apply.EventDate, apply.EventTime, apply.EventLocation, apply.Notification, apply.NotificationTime, apply.SelectedTimeFrame, apply.Repeated);
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Hurrayfull!");

                    }
                    else
                    {
                        String query = String.Format("INSERT INTO EventDB(EventName, EventDescription,EventDate, EventTime, EventLocation, ISNotification) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", apply.EventName, apply.EventDescription, apply.EventDate, apply.EventTime, apply.EventLocation, apply.Notification);
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Hurrayshort!");
                    }
                }
            }
        }
    }


internal class CancelCommand : ICommand
{
    public event EventHandler CanExecuteChanged;


    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
    }

}
}