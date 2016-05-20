using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using XF.Windows.Common;

namespace Arges
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
   {
        private StateManager _StateManager = null;

        //public UserControl MainView { get; set; }
        public Func<UserControl> GetMainView { get; set; }

        public Shell()
        {
            InitializeComponent();
            _StateManager = Application.Current.Properties[XUXConstants.StateManager] as StateManager;
            _StateManager.RegisterEndpointAction(ActivityStateOption.Authenticated.ToString(), EndpointOption.Arrival, OnAuthenticated);
            _StateManager.RegisterEndpointAction(ActivityStateOption.Authorized.ToString(), EndpointOption.Arrival, OnAuthorized);
            _StateManager.RegisterEndpointAction(ActivityStateOption.LoggedOff.ToString(), EndpointOption.Arrival, OnLoggedOff);
            _StateManager.RegisterEndpointAction(ActivityStateOption.Unauthorized.ToString(), EndpointOption.Arrival, OnUnauthorized);
            _StateManager.RegisterEndpointAction(ActivityStateOption.Error.ToString(), EndpointOption.Arrival, OnError);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _StateManager.Machine.ExecuteTransition(TransitionTypeOption.Login.ToString());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_StateManager.CurrentState.Equals(ActivityStateOption.LoggedOff.ToString()))
            {
                e.Cancel = true;
                _StateManager.Machine.ExecuteTransition(TransitionTypeOption.Logoff.ToString());
            }
        }

        private void OnAuthenticated()
        {
            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(new AuthorizationView());
        }

        private void OnAuthorized()
        {
            bool b = false;
            LayoutRoot.Children.Clear();
            if (GetMainView != null)
            {
                UserControl ctl = GetMainView();
                if (ctl != null)
                {
                    b = true;
                    LayoutRoot.Children.Add(ctl);
                }
            }
            if (!b)
            {
                LayoutRoot.Children.Add(new AuthorizedView() { LocalView = new WorkspaceView() });
            }
            LoadGlobalData();
        }

        private void OnError()
        {
            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(new ErrorView());
        }

        private void OnLoggedOff()
        {
            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(new LogoffView());
        }

        private void OnUnauthorized()
        {
            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(new UnauthorizedView());
        }

        private void RemoveOverlay()
        {
            LayoutRoot.Children.RemoveAt(LayoutRoot.Children.Count - 1);
        }

        private void ShowContentOverlay(dynamic args)
        {
            OverlayView overlay = new OverlayView() { Close = RemoveOverlay };
            //overlay.grdOverlay.Children.Add(args.Control);
            overlay.SetOverlay(args.Control);
            overlay.SetTitle((string)args.Title);
            LayoutRoot.Children.Add(overlay);
        }

        private void LoadGlobalData()
        {
        }



    }
}
