using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Calendrier.Converter
{
    [ValueConversion(typeof(DateTime), typeof(string))]
    class WeekConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) throw new NullReferenceException("la valeur ne peut pas être null");
            var d = (DateTime)value;
            return CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int)d.DayOfWeek];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
