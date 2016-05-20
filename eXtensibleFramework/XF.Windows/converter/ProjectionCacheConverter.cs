// <copyright file="DisplayItemCacheConverter.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Data;
    using XF.Common;

    public sealed class DisplayItemCacheConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter != null && !String.IsNullOrEmpty(parameter.ToString()))
            {
                List<Projection> list = ProjectionReadThroughCache.Instance.GetAll(parameter);
                if (list != null && list.Count > 0)
                {
                    var found = list.Find(x => x.Id.Equals(value.ToString(), StringComparison.OrdinalIgnoreCase));
                    if (found != null)
                    {
                        return found.Display;
                    }
                }
            }
            else
            {
            }
            int i = 0;
            int j = i;
            return value;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}