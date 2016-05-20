using Cyclops;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        public WorkspaceView()
        {
            InitializeComponent();

            _Workspace = System.Windows.Application.Current.Properties[AppConstants.Workspace] as Workspace;
            ViewModel = new WorkspaceViewModel(_Workspace)
            {
                Service = System.Windows.Application.Current.Properties[AppConstants.ModelRequestService] as IModelRequestService
            };
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
