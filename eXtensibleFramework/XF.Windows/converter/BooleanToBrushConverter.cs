

namespace XF.Windows.Common
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    public class BooleanToBrushConverter : IValueConverter
    {

        public Brush DefaultBrush { get; set; }

        public Brush FalseBrush { get; set; }

        public Brush TrueBrush { get; set; }

        #region IValueConverter Members

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = false;
            Brush selected = (DefaultBrush != null) ? DefaultBrush : Brushes.Black;
            Brush trueBrush = (TrueBrush != null) ? TrueBrush : Brushes.Green;
            Brush falseBrush = (FalseBrush != null) ? FalseBrush : Brushes.Red;
            if (value != null && Boolean.TryParse(value.ToString(), out b))
            {
                selected = (b) ? trueBrush : falseBrush;
            }
            return selected;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
