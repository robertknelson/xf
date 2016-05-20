using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XF.Windows.Common;

namespace Arges
{
    public class WindowsServerViewModel : SortableViewModel<WindowsServer>
    {

        #region ExternalIP (string)

        /// <summary>
        /// Gets or sets the string value for InternalIP
        /// </summary>
        /// <value> The string value.</value>

        public string ExternalIP
        {
            get { return (String.IsNullOrEmpty(Model.ExternalIP)) ? String.Empty : Model.ExternalIP; }
            set
            {
                if (Model.ExternalIP != value)
                {
                    Model.ExternalIP = value;
                    OnPropertyChanged("InternalIP");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region Token (string)

        /// <summary>
        /// Gets or sets the string value for Token
        /// </summary>
        /// <value> The string value.</value>

        public string Token
        {
            get { return (String.IsNullOrEmpty(Model.Token)) ? String.Empty : Model.Token; }
            set
            {
                if (Model.Token != value)
                {
                    Model.Token = value;
                    OnPropertyChanged("Token");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region Name (string)

        /// <summary>
        /// Gets or sets the string value for Name
        /// </summary>
        /// <value> The string value.</value>

        public string Name
        {
            get { return (String.IsNullOrEmpty(Model.Name)) ? String.Empty : Model.Name; }
            set
            {
                if (Model.Name != value)
                {
                    Model.Name = value;
                    OnPropertyChanged("Name");
                    IsDirty = true;
                }
            }
        }

        #endregion

        public override void Initialize(WindowsServer model)
        {
            Model = model;
        }


    }
}

