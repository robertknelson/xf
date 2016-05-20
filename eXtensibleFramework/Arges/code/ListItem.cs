// <copyright company="eXtensoft, LLC" file="ListItem.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace Arges
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    [Serializable]
    public class ListItem
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("i")]
        public int Index { get; set; }

        [XmlAttribute("t")]
        public string Token { get; set; }

        [XmlAttribute("m")]
        public string Master { get; set; }

        [XmlAttribute("g")]
        public string Group { get; set; }




        [XmlText]
        public string Text { get; set; }

    }

}
