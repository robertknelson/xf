using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arges
{
    public class Workspace
    {
        public SelectionConverter Converter { get; set; }

        #region Servers (List<ServerViewModel>)

        private List<ServerViewModel> _Servers;

        /// <summary>
        /// Gets or sets the List<ServerViewModel> value for Servers
        /// </summary>
        /// <value> The List<ServerViewModel> value.</value>

        public List<ServerViewModel> Servers
        {
            get { return _Servers; }
            set
            {
                if (_Servers != value)
                {
                    _Servers = value;
                }
            }
        }

        #endregion


        public Workspace(IEnumerable<Cyclops.Selection> selections)
        {
            Converter = new SelectionConverter(selections.ToList()) { };
        }

        public bool Initialize(IEnumerable<Cyclops.Server> servers)
        {
            bool b = false;
            _Servers = (from x in servers
                        select new ServerViewModel(x) {
                            OperatingSystem = Converter.Convert(x.OperatingSystemId),
                            HostPlatform = Converter.Convert(x.HostPlatformId),
                            Security = Converter.Convert(x.SecurityId)
                        }).ToList();

            return b;
        }
    }
}
