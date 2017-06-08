using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab1
{
    class EventTimeValidation: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                DateTime usertime = Convert.ToDateTime(value);
                if (((usertime == DateTime.Now.Date) && (usertime.TimeOfDay < DateTime.Now.TimeOfDay)) || (usertime < DateTime.Now.Date))  return new ValidationResult(false, "The time has already passed!");


            }
            catch (Exception e)
            {
                return new ValidationResult(false, "The time format is wrong!");
            }
            return new ValidationResult(true, string.Empty);
        }
    }
}
