// <copyright file="ImageMapConverter.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;

    public class ImageMapConverter : IValueConverter
    {
        #region IValueConverter Members

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string path = "images/content.text.png";
            string prefix = (parameter == null) ? String.Empty : parameter.ToString();
            if (value != null && !String.IsNullOrEmpty(value.ToString()))
            {
                List<Tuple<string, string>> list = Application.Current.Properties[XUXConstants.ImageMaps] as List<Tuple<string, string>>;
                if (list != null)
                {
                    Tuple<string, string> found = list.FirstOrDefault(x => x.Item1.Equals(value.ToString(), StringComparison.OrdinalIgnoreCase));
                    if (found != null)
                    {
                        path = (!String.IsNullOrEmpty(prefix)) ? prefix + found.Item2 : found.Item2;
                    }
                    else
                    {
                        path = (!String.IsNullOrEmpty(prefix)) ? prefix + path : path;
                    }
                }
            }
            return path;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion IValueConverter Members
    }
}