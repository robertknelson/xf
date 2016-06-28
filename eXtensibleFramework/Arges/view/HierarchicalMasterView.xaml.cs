using System.Windows;
using System.Windows.Controls;

namespace Arges
{
    /// <summary>
    /// Interaction logic for HierarchicalMasterView.xaml
    /// </summary>
    public partial class HierarchicalMasterView : UserControl
    {
        public HierarchicalMasterView()
        {
            InitializeComponent();
        }

        private void ctlItems_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            WorkspaceViewModel  wvm = this.DataContext as WorkspaceViewModel;
            ServerViewModel vm = e.NewValue as ServerViewModel;
            if (wvm != null && vm != null )
            {
                wvm.SelectedItem = vm;
            }
        }
    }
}
