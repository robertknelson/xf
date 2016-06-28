using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Arges
{
    [Serializable]
    [DataContract(Namespace = "")]
    public class ServerCredentials
    {
        public WindowsCredential Credential { get; set; }

        public List<WindowsServer> Servers { get; set; }
    }
}
