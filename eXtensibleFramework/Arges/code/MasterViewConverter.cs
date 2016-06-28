// <copyright company="eXtensoft, LLC" file="MasterViewConverter.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace Arges
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    public sealed class MasterViewConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
