using System;
using System.Windows.Input;
using XF.Windows.Common;

namespace Arges
{
    public class ServerViewModel : ViewModel<Cyclops.Server>
    {
        #region operational properties

        #region Master (string)

        private string _Master;

        /// <summary>
        /// Gets or sets the string value for Master
        /// </summary>
        /// <value> The string value.</value>

        public string Master
        {
            get { return (String.IsNullOrEmpty(_Master)) ? String.Empty : _Master; }
            set
            {
                if (_Master != value)
                {
                    _Master = value;
                    OnPropertyChanged("Master");
                }
            }
        }

        #endregion


        #region Label (string)

        private string _Label;

        /// <summary>
        /// Gets or sets the string value for Label
        /// </summary>
        /// <value> The string value.</value>

        public string Label
        {
            get { return (String.IsNullOrEmpty(_Label)) ? String.Empty : _Label; }
            set
            {
                if (_Label != value)
                {
                    _Label = value;
                    OnPropertyChanged("Label");
                }
            }
        }

        #endregion

        #endregion


        #region properties

        #region IsSelected (bool)

        private bool _IsSelected;

        /// <summary>
        /// Gets or sets the bool value for IsSelected
        /// </summary>
        /// <value> The bool value.</value>

        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        #endregion

        #region ServerId (int)

        /// <summary>
        /// Gets or sets the int value for ServerId
        /// </summary>
        /// <value> The int value.</value>

        public int ServerId
        {
            get { return Model.ServerId; }
            set
            {
                if (Model.ServerId != value)
                {
                    Model.ServerId = value;
                    OnPropertyChanged("ServerId");
                    IsDirty = true;
                }
            }
        }

        #endregion

        public string OperatingSystem { get;  set; }

        public string HostPlatform { get;  set; }

        public string Security { get;  set; }

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

        #region Description (string)

        /// <summary>
        /// Gets or sets the string value for Description
        /// </summary>
        /// <value> The string value.</value>

        public string Description
        {
            get { return (String.IsNullOrEmpty(Model.Description)) ? String.Empty : Model.Description; }
            set
            {
                if (Model.Description != value)
                {
                    Model.Description = value;
                    OnPropertyChanged("Description");
                    IsDirty = true;
                }
            }
        }

        #endregion
  
        #region ExternalIP (string)

        /// <summary>
        /// Gets or sets the string value for ExternalIP
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
                    OnPropertyChanged("ExternalIP");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region InternalIP (string)

        /// <summary>
        /// Gets or sets the string value for InternalIP
        /// </summary>
        /// <value> The string value.</value>

        public string InternalIP
        {
            get { return (String.IsNullOrEmpty(Model.InternalIP)) ? String.Empty : Model.InternalIP; }
            set
            {
                if (Model.InternalIP != value)
                {
                    Model.InternalIP = value;
                    OnPropertyChanged("InternalIP");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #endregion

        private ICommand _RdpCommand;

        public ICommand RdpCommand
        {
            get
            {
                if (_RdpCommand == null)
                {
                    _RdpCommand = new RelayCommand(
                        param => ExecuteRdp(),
                        param => CanExecuteRdp());
                }
                return _RdpCommand;
            }
        }

        private bool CanExecuteRdp()
        {
            return true;
        }

        private void ExecuteRdp()
        {
            //var credentials = CredentialsManager.ResolveCredentials(ExternalIP);
            var credentials = CredentialsManager.ResolveCredentials(ServerId);
            if (credentials != null)
            {
                string s = credentials.ToString();
                RemoteDesktop.Connect(ExternalIP, credentials.ToString(), credentials.Password);
            }
            else
            {
                RemoteDesktop.Connect(ExternalIP);
            }
        }
        public ServerViewModel() { }

        public ServerViewModel(Cyclops.Server model)
        {
            Model = model;
        }
    }

}
