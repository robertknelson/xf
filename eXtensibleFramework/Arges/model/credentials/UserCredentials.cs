using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Arges
{

    [DataContract(Namespace = "")]
    [Serializable]   
    public class UserCredentials
    {
        [DataMember]
        [XmlAttribute("display")]
        public string Display { get; set; }

        [DataMember]
        public List<ServerCredentials> Credentials { get; set; }

        [DataMember]
        public DateTime LastUpdatedAt { get; set; }

    }
}
