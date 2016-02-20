// <copyright company="eXtensoft, LLC" file="eXtensibleFrameworkElement.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System.Configuration;

    public sealed class eXtensibleFrameworkElement : ConfigurationElement
    {
        public eXtensibleFrameworkElement()
        {
        }

        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("loggingStrategy", IsRequired = true)]
        public string LoggingStrategy
        {
            get { return (string)this["loggingStrategy"]; }
            set { this["loggingStrategy"] = value; }
        }

        [ConfigurationProperty("publishSeverity", IsRequired = true)]
        public string PublishSeverity
        {
            get { return (string)this["publishSeverity"]; }
            set
            {
                this["publishSeverity"] = value;
            }
        }

        [ConfigurationProperty("inform", IsRequired = false )]
        public bool Inform
        {
            get { return (bool)this["inform"]; }
            set { this["inform"] = value; }
        }
    }
}