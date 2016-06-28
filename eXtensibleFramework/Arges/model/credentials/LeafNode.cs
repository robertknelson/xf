// <copyright company="eXtensoft, LLC" file="LeafNode.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace Arges
{
    using System.Xml;
    using System.Xml.Serialization;

    public sealed class LeafNode : Node
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        public override NodeTypeOption NodeType
        {
            get
            {
                return NodeTypeOption.Leaf;
            }
        }
    }

}
