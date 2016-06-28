using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Arges
{
    [DataContract(Namespace = "")]
    [Serializable]
    public class WindowsServer
    {
        [DataMember]
        [XmlAttribute("id")]
        public int ServerId { get; set; }

        [IgnoreDataMember]
        [XmlAttribute("grp")]
        public string GroupName { get; set; }

        [IgnoreDataMember]
        [XmlIgnore]
        public string Master { get; set; }

        [XmlAttribute("ip")]
        public string ExternalIP { get; set; }
        
    }
}
