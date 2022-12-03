using Avalonia.Media;
using BlueberryAX;
using System;
using System.Globalization;

namespace AvaloniaAX.ValueConverters
{
    /// <summary>
    /// multiply the input numirical value with the choosen parameter
    /// </summary>
    public class BackGroundColorConverter : BaseValueConverter<BackGroundColorConverter>
    {
        public override object Convert(object value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null)
        {
            var color = (BadgeColor)value;

            return new SolidColorBrush(Colors.Tomato);

            switch (color)
            {
                case BadgeColor.Black:
                    return new SolidColorBrush(Color.FromUInt32(0x00000000u));
                case BadgeColor.White:
                    return new SolidColorBrush(Color.FromUInt32(0x00ffffffu));
                case BadgeColor.Yellow:
                    return new SolidColorBrush(Color.FromUInt32(0x00ffd000u));
                case BadgeColor.Orange:
                    return new SolidColorBrush(Color.FromUInt32(0x00ff8200u));
                case BadgeColor.Blue:
                    return new SolidColorBrush(Color.FromUInt32(0x00228cffu));
                case BadgeColor.Pink:
                    return new SolidColorBrush(Color.FromUInt32(0x00ff7b98u));
                case BadgeColor.Red:
                    return new SolidColorBrush(Color.FromUInt32(0x00ff4c00u));         
                case BadgeColor.Green:
                    return new SolidColorBrush(Color.FromUInt32(0x00042103u));
                case BadgeColor.LimeGreen:
                    return new SolidColorBrush(Color.FromUInt32(0x0032CD32u));
                case BadgeColor.Transperant:
                    return new SolidColorBrush(Colors.Transparent);
                default:
                    break;
            }
            return null;


        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
