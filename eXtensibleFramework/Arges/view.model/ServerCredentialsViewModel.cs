using System;
using XF.Windows.Common;

namespace Arges
{
    public class ServerCredentialsViewModel : ViewModel<ServerCredentials>
    {

        #region Id (Guid)

        /// <summary>
        /// Gets or sets the Guid value for Id
        /// </summary>
        /// <value> The Guid value.</value>

        public Guid Id
        {
            get { return (Model.Credential.Id != null) ? Model.Credential.Id : Guid.Empty; }
            set
            {
                if (Model.Credential.Id != value)
                {
                    Model.Credential.Id = value;
                    OnPropertyChanged("Id");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region Domain (string)

        /// <summary>
        /// Gets or sets the string value for Domain
        /// </summary>
        /// <value> The string value.</value>

        public string Domain
        {
            get { return (String.IsNullOrEmpty(Model.Credential.Domain)) ? String.Empty : Model.Credential.Domain; }
            set
            {
                if (Model.Credential.Domain != value)
                {
                    Model.Credential.Domain = value;
                    OnPropertyChanged("Domain");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region Username (string)

        /// <summary>
        /// Gets or sets the string value for Username
        /// </summary>
        /// <value> The string value.</value>

        public string Username
        {
            get { return (String.IsNullOrEmpty(Model.Credential.Username)) ? String.Empty : Model.Credential.Username; }
            set
            {
                if (Model.Credential.Username != value)
                {
                    Model.Credential.Username = value;
                    OnPropertyChanged("Username");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region Password (string)

        /// <summary>
        /// Gets or sets the string value for Password
        /// </summary>
        /// <value> The string value.</value>

        public string Password
        {
            get { return (String.IsNullOrEmpty(Model.Credential.Password)) ? String.Empty : Model.Credential.Password; }
            set
            {
                if (Model.Credential.Password != value)
                {
                    Model.Credential.Password = value;
                    OnPropertyChanged("Password");
                    IsDirty = true;
                }
            }
        }

        #endregion

        public SortableObservableCollection<WindowsServer, WindowsServerViewModel> Servers { get; set; }

        public ServerCredentialsViewModel(ServerCredentials model)
        {
            Model = model;
            Servers = new SortableObservableCollection<WindowsServer, WindowsServerViewModel>(model.Servers);
        }



    }
}
