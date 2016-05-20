using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Arges
{
    [DataContract(Namespace = "")]
    [Serializable]
    public class WindowsServer
    {
        [DataMember]
        [XmlAttribute("ip")]
        public string ExternalIP { get; set; }

        [IgnoreDataMember]
        [XmlIgnore]
        public string Token { get; set; }

        [IgnoreDataMember]
        [XmlIgnore]
        public string Name { get; set; }
    }
}
