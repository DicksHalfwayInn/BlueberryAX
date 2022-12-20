using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueberryAX.ValueConverters
{

    /// <summary>
    /// multiply the input numirical value with the choosen parameter
    /// </summary>
    public class BooleanToIsVisibleConverter : BaseValueConverter<BooleanToIsVisibleConverter>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            if ((bool)value)
            {
                return true;
            }
            return !(bool)value;

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
