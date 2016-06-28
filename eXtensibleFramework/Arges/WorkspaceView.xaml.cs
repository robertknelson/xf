using System.ComponentModel;
using System.Windows.Controls;
using XF.Common;

namespace Arges
{
    /// <summary>
    /// Interaction logic for WorkspaceView.xaml
    /// </summary>
    public partial class WorkspaceView : UserControl, INotifyPropertyChanged
    {
        private Workspace _Workspace;

        public WorkspaceViewModel ViewModel { get; set; }

        #region MasterView

        public bool IsSimple
        {
            get { return _MasterView.Equals(MasterViewOption.Simple); }
            set
            {
                if (value == true)
                {
                    MasterView = MasterViewOption.Simple;
                }
            }
        }

        public bool IsHierarchical
        {
            get { return _MasterView.Equals(MasterViewOption.Hierarchical); }
            set
            {
                if (value == true)
                {
                    MasterView = MasterViewOption.Hierarchical;
                }
            }
        }

        public bool IsGrouped
        {
            get { return _MasterView.Equals(MasterViewOption.Grouped); }
            set
            {
                if (value == true)
                {
                    MasterView = MasterViewOption.Grouped;
                }
            }
        }

        #endregion

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
                    OnPropertyChanged("IsSimple");
                    OnPropertyChanged("IsGrouped");
                    OnPropertyChanged("IsHierarchical");
                    
                    UserControl ctl = null;
                    switch (value)
                    {
                        case MasterViewOption.None:                            
                            break;
                        case MasterViewOption.Simple:
                            ctl = SimpleView;
                            break;
                        case MasterViewOption.Grouped:
                            ctl = GroupedView;
                            break;
                        case MasterViewOption.Hierarchical:
                            ctl = HierarchicalView;
                            break;
                        default:
                            break;
                    }
                    grdMaster.Children.Clear();
                    grdMaster.Children.Add(ctl);
                }
            }
        }

        #endregion


        #region HierarchicalView (UserControl)

        private UserControl _HierarchicalView;

        /// <summary>
        /// Gets or sets the UserControl value for HierarchicalView
        /// </summary>
        /// <value> The UserControl value.</value>

        public UserControl HierarchicalView
        {
            get {
                if (_HierarchicalView == null)
                {
                    _HierarchicalView = new HierarchicalMasterView();
                }

                return _HierarchicalView; }

        }

        #endregion


        #region SimpleView (UserControl)

        private UserControl _SimpleView;

        /// <summary>
        /// Gets or sets the UserControl value for SimpleView
        /// </summary>
        /// <value> The UserControl value.</value>

        public UserControl SimpleView
        {
            get {
                if (_SimpleView == null)
                {
                    _SimpleView = new SimpleMasterView();
                }

                return _SimpleView; }

        }

        #endregion


        #region GroupedView (UserControl)

        private UserControl _GroupedView;

        /// <summary>
        /// Gets or sets the UserControl value for GroupedView
        /// </summary>
        /// <value> The UserControl value.</value>

        public UserControl GroupedView
        {
            get
            {
                if (_GroupedView == null)
                {
                    _GroupedView = new GroupedMasterView();
                }
                return _GroupedView;
            }

        }

        #endregion

        public WorkspaceView()
        {
            InitializeComponent();


            this.ViewModel = System.Windows.Application.Current.Properties[AppConstants.WorkspaceViewModel] as WorkspaceViewModel;
            _Workspace = ViewModel.Model;
            this.DataContext = ViewModel;
            OnPropertyChanged("ViewModel");
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPropertyChanged Members


    }
}
