// <copyright file="StringFormatConverter.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Data;

    public class StringFormatConverter : IValueConverter
    {
        #region IValueConverter Members

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object o = value;
            if (parameter != null && !String.IsNullOrEmpty(parameter.ToString()))
            {
                string key = parameter.ToString();
                Dictionary<string, string> d = Application.Current.Properties[XUXConstants.FormatStrings] as Dictionary<string, string>;
                if (d != null && d.ContainsKey(key))
                {
                    string text = d[key];
                    return String.Format(text, o.ToString());
                }
            }
            return o.ToString();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion IValueConverter Members
    }
}