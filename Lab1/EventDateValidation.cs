using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab1
{
    class EventDateValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                DateTime userdate = Convert.ToDateTime(value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "The date format is wrong!");
            }
            if (Convert.ToDateTime(value).Date < DateTime.Now.Date) return new ValidationResult(false, "The date has already passed!");
            return new ValidationResult(true, string.Empty);
        }
    }
}
