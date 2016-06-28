using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using XF.Common;
using XF.Windows.Common;

namespace Arges
{
    public class WorkspaceViewModel : ViewModel<Workspace>
    {
        public UserCredentialsViewModel Credentials { get; set; }

        public IModelRequestService Service { get; set; }

        #region Groupings (ObservableCollection<GroupingViewModel>)

        private ObservableCollection<GroupingViewModel> _Groupings = new ObservableCollection<GroupingViewModel>();

        /// <summary>
        /// Gets or sets the ObservableCollection<GroupingViewModel> value for Groupings
        /// </summary>
        /// <value> The ObservableCollection<GroupingViewModel> value.</value>

        public ObservableCollection<GroupingViewModel> Groupings
        {
            get { return _Groupings; }
            set
            {
                if (_Groupings != value)
                {
                    _Groupings = value;
                    OnPropertyChanged("Groupings");
                }
            }
        }

        #endregion


        #region SelectedItem (ServerViewModel)

        private ServerViewModel _SelectedItem;

        /// <summary>
        /// Gets or sets the ServerViewModel value for SelectedItem
        /// </summary>
        /// <value> The ServerViewModel value.</value>

        public ServerViewModel SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        #endregion

        #region ListView (ObservableCollection<ServerViewModel>)

        private ObservableCollection<ServerViewModel> _ListView = new ObservableCollection<ServerViewModel>();

        /// <summary>
        /// Gets or sets the ObservableCollection<ServerViewModel> value for ListView
        /// </summary>
        /// <value> The ObservableCollection<ServerViewModel> value.</value>

        public ObservableCollection<ServerViewModel> ListView
        {
            get { return _ListView; }
            set
            {
                if (_ListView != value)
                {
                    _ListView = value;
                }
            }
        }

        #endregion

        private ICommand _RefreshServersCommand;
        public ICommand RefreshServersCommand
        {
            get
            {

                if (_RefreshServersCommand == null)
                {
                    _RefreshServersCommand = new RelayCommand(
                        param => RefreshServers(),
                        param => CanRefreshServers()
                        );
                }
                return _RefreshServersCommand;
            }
        }

        private bool CanRefreshServers()
        {
            return true;
        }

        private void RefreshServers()
        {
            Service.GetAllAsync<Cyclops.Server>(null, HandleGetAllServers);
        }

        private void HandleGetAllServers(IEnumerable<Cyclops.Server> list)
        {
            List<ServerViewModel> servers = (from x in list select new ServerViewModel(x) {
                    OperatingSystem = Model.Converter.Convert(x.OperatingSystemId),
                    HostPlatform = Model.Converter.Convert(x.HostPlatformId),
                    Security = Model.Converter.Convert(x.SecurityId)
            }).ToList();

            Groupings.Add(new ServerGroupingViewModel("Servers", servers));
            ListView = new ObservableCollection<ServerViewModel>(servers);

        }

        public WorkspaceViewModel(Workspace model)
        {
            Model = model;
        }




    }
}
