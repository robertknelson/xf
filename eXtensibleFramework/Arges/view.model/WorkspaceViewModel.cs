using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XF.Common;
using XF.Windows.Common;

namespace Arges
{
    public class WorkspaceViewModel : ViewModel<Workspace>
    {

        public IModelRequestService Service { get; set; }


        #region MasterView (MasterViewOption)


        /// <summary>
        /// Gets or sets the MasterViewOption value for MasterView
        /// </summary>
        /// <value> The MasterViewOption value.</value>
        private MasterViewOption _MasterView;
        public MasterViewOption MasterView
        {
            get { return _MasterView; }
            set
            {
                if (_MasterView != value)
                {
                    _MasterView = value;
                    OnPropertyChanged("MasterView");
                }
            }
        }

        #endregion

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

            var grp = new ServerGroupingViewModel("Servers",
                (from x in list select new ServerViewModel(x) {
                    OperatingSystem = Model.Converter.Convert(x.OperatingSystemId),
                    HostPlatform = Model.Converter.Convert(x.HostPlatformId),
                    Security = Model.Converter.Convert(x.SecurityId)
                }).ToList());
            Groupings.Add(grp);

        }

        public WorkspaceViewModel(Workspace model)
        {
            Model = model;
        }




    }
}
