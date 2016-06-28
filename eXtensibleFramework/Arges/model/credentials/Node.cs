// <copyright company="eXtensoft, LLC" file="Node.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace Arges
{
    using System.Xml;
    using System.Xml.Serialization;
    using System.Runtime.Serialization;

    [KnownType(typeof(BranchNode))]
    [KnownType(typeof(LeafNode))]
    public abstract class Node
    {
        [XmlIgnore]
        public abstract NodeTypeOption NodeType { get; }
        [XmlAttribute("l")]
        public string Label { get; set; }

        [XmlAttribute("m")]
        public string Master { get; set; }
    }

}
