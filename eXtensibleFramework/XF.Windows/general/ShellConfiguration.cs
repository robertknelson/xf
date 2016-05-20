// <copyright file="ShellConfiguration.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Configuration;

    public sealed class ShellConfiguration
    {
        public static double ShellHeight { get { return GetConfigValueAs<double>("ShellHeight"); } }

        public static double ShellWidth { get { return GetConfigValueAs<double>("ShellWidth"); } }

        private static T GetConfigValueAs<T>(string key) where T : IConvertible
        {
            T t = default(T);
            string s = ConfigurationManager.AppSettings[key];
            if (!String.IsNullOrEmpty(s))
            {
                t = Parse<T>(s);
            }
            return t;
        }

        private static T Parse<T>(string valueToConvert) where T : IConvertible
        {
            return (T)Convert.ChangeType(valueToConvert, typeof(T));
        }
    }
}