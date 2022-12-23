using Avalonia.Data.Converters;
using Avalonia.Data;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Avalonia;

namespace BlueberryAX.ValueConverters
{
    public class NumberToCornerRadiusConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
          
            if (value != null)
            {
                try
                {
                    return new CornerRadius((double)value);
                }
                catch
                {
                    return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
                }
            }
            else 
            return new BindingNotification(new NullReferenceException(), BindingErrorType.Error);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
