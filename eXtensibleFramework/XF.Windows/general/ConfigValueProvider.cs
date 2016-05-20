// <copyright file="ConfigValueProvider.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Configuration;

    public static class ConfigValueProvider
    {
        public static double ShellHeight { get { return GetConfigValueAs<double>("ShellHeight", 750); } }

        public static double ShellWidth { get { return GetConfigValueAs<double>("ShellWidth", 1300); } }

        public static string ShellTitle { get { return GetConfigValueAs<string>("ShellTitle", "Application Title"); } }

        private static T GetConfigValueAs<T>(string key, T defaultValue) where T : IConvertible
        {
            T t = defaultValue;
            string s = ConfigurationManager.AppSettings[key];
            if (!String.IsNullOrEmpty(s))
            {
                t = Parse<T>(s);
            }
            return t;
        }

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