using System;
using System.Windows;
using System.Windows.Controls;
using XF.Windows.Common;

namespace Arges
{
    /// <summary>
    /// Interaction logic for AuthorizationView.xaml
    /// </summary>
    public partial class AuthorizationView : UserControl
    {
        private System.Timers.Timer _Timer = null;

        public AuthorizationView()
        {
            InitializeComponent();
            _Timer = new System.Timers.Timer(1000.00);
            _Timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            _Timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _Timer.Stop();

            Dispatcher.Invoke((Action)(() =>
            {
                StateManager manager = Application.Current.Properties[XUXConstants.StateManager] as StateManager;
                manager.Machine.ExecuteTransition(TransitionTypeOption.Authorize.ToString());
            }));
        }

        private void ExecuteTransition()
        {
            StateManager manager = Application.Current.Properties[XUXConstants.StateManager] as StateManager;
            manager.Machine.ExecuteTransition(TransitionTypeOption.Authorize.ToString());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _Timer.Start();
        }
    }
}
