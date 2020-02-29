using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ClashOfClansManager.Model
{
    public class UTCConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string utcTime;
            string years, months, days, hours, minutes, secondes;
            string result;
            string dseparator = "-";
            string hseparator = ":";

            if (value == null)
                result = string.Empty;

            utcTime = value.ToString();
            years = utcTime.Substring(0, 4);
            months = utcTime.Substring(4, 2);
            days = utcTime.Substring(6, 2);
            hours = utcTime.Substring(9, 2);
            minutes = utcTime.Substring(11, 2);
            secondes = utcTime.Substring(13, 2);
            result =
                years
                + dseparator
                + months
                + dseparator
                + days
                + " "
                + hours
                + hseparator
                + minutes
                + hseparator
                + secondes;

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
