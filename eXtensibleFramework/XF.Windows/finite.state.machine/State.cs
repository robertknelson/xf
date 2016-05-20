// <copyright file="State.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [Serializable]
    public class State
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        #region Display (string)

        private string _Display;

        /// <summary>
        /// Gets or sets the string value for Display
        /// </summary>
        /// <value> The string value.</value>
        [XmlAttribute("display")]
        public string Display
        {
            get { return (String.IsNullOrEmpty(_Display)) ? Name : _Display; }
            set
            {
                if (_Display != value)
                {
                    _Display = value;
                }
            }
        }

        #endregion Display (string)

        [XmlIgnore]
        public List<IEndpointAction> EndpointActions { get; set; }
    }
}