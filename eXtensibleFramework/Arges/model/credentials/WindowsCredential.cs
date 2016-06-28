using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Arges
{
    [Serializable]
    [DataContract(Namespace = "")]
    public class WindowsCredential
    {
        [DataMember]
        [XmlAttribute("id")]
        public Guid Id { get; set; }

        [DataMember]
        [XmlAttribute("display")]
        public string Name { get; set; }
        [DataMember]
        [XmlAttribute("domain")]
        public string Domain { get; set; }
        [DataMember]
        [XmlAttribute("name")]
        public string Username { get; set; }
        [DataMember]
        [XmlAttribute("pwd")]
        public string Password { get; set; }

        public override string ToString()
        {
            return String.Format("{0}\\{1}", Domain, Username);
        }
    }
}
