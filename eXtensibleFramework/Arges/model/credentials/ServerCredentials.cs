using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
