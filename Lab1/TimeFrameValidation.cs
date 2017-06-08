using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab1
{
    class TimeFrameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            UInt32 UserNotificationTime = 0;
            try
            {
                UserNotificationTime = Convert.ToUInt32(value);
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, "Time cannot be negative!");
            }
            switch ((string)value)
            {
                default:
                    {
                        if (UserNotificationTime > 60) return new ValidationResult(false, "The max number of minutes is 60!");
                    }
                    break;
                case "часов":
                    {
                        if (UserNotificationTime > 24) return new ValidationResult(false, "The max number of hours is 24!");
                    }
                    break;
                case "дней":
                    {
                        if (UserNotificationTime > 365) return new ValidationResult(false, "The max number of days is 365!");
                    }
                    break;
            }
            return new ValidationResult(true, string.Empty);
        }
    }
}
