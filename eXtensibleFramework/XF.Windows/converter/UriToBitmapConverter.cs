// <copyright file="UriToBitmapConverter.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    public class UriToBitmapConverter : IValueConverter
    {
        #region IValueConverter Members

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string directory = Application.Current.Properties[XUXConstants.ContentDirectory] as string;
            if (!String.IsNullOrEmpty(directory))
            {
                string filepath = System.IO.Path.Combine(directory, value.ToString());
                BitmapImage image = new BitmapImage();
                image.BeginInit();

                //image.DecodePixelWidth = 512;
                image.CacheOption = BitmapCacheOption.OnLoad;

                image.UriSource = new Uri(filepath);
                image.EndInit();

                return image;
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