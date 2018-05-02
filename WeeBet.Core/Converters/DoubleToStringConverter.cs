using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;

namespace WeeBet.Core.Converters
{
    public class DoubleToStringConverter : MvxValueConverter<double, string>
    {
        protected override string Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
    }
}
