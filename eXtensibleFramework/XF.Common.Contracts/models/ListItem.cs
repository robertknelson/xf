// <copyright company="eXtensoft, LLC" file="ListItem.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract(Namespace = "http://eXtensibleSolutions/schemas/2014/04")]
    public class ListItem
    {
        [XmlAttribute("group")]
        [DataMember]
        public string Group { get; set; }

        [XmlAttribute("tds")]
        [DataMember]
        public DateTime Tds { get; set; }

        [XmlElement]
        [DataMember]
        public string Display { get; set; }

        [XmlElement("Item")]
        [DataMember]
        public List<TypedItem> Items { get; set; }

        public ListItem()
        {
            Items = new List<TypedItem>();
        }
    }
}
