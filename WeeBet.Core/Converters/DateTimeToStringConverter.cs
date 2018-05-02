using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeeBet.Core.Converters
{
    public class DateTimeToStringConverter :
        MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value.ToString("d/M hh:mm");
        }
    }
}
