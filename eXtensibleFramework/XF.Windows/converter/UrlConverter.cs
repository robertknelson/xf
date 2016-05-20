// <copyright file="UrlConverter.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Windows.Data;

    public class UrlConverter : IValueConverter
    {
        #region IValueConverter Members

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && !String.IsNullOrEmpty(value.ToString()))
            {
                string s = value.ToString();
                if (!s.StartsWith("http://"))
                {
                    return String.Format("http://{0}", s);
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return value;
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion IValueConverter Members
    }
}