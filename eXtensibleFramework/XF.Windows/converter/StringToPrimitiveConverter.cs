// <copyright file="StringToPrimitiveConverter.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Windows.Data;

    public class StringToPrimitiveConverter : IValueConverter
    {
        #region IValueConverter Members

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && (parameter != null))
            {
                switch (parameter.ToString())
                {
                    case "System.Int64":
                    case "Int64":
                    case "long":
                        return Int64.Parse(value.ToString());

                    case "System.Int32":
                    case "Int32":
                    case "int":
                        return Int32.Parse(value.ToString());

                    default:
                        return null;
                }
            }
            else
            {
                return null;
            }

            //object o = null;
            //Type t = Type.GetType(parameter.ToString());
            //if (t != null)
            //{
            //    //o = Parse < typeof(t) > (value);

            //}
            //return o;
        }

        #endregion IValueConverter Members

        private T Parse<T>(string valueToConvert) where T : IConvertible
        {
            return (T)Convert.ChangeType(valueToConvert, typeof(T));
        }
    }
}