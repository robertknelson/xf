using System;
using System.Windows;
using System.Windows.Controls;

namespace Arges
{
    /// <summary>
    /// Interaction logic for OverlayView.xaml
    /// </summary>
    public partial class OverlayView : UserControl
    {
        private Visibility _CloseButtonVisibility = Visibility.Visible;



        public Visibility CloseButtonVisibility
        {
            get
            {
                return _CloseButtonVisibility;
            }
            set { _CloseButtonVisibility = value; }
        }

        public Action Close { get; set; }

        public OverlayView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Close != null)
            {
                Close.Invoke();
            }
        }

        public void SetTitle(string title)
        {
            txbTitle.Text = title;
            txbTitle.Visibility = System.Windows.Visibility.Visible;
        }
        public void SetOverlay(dynamic args)
        {
            grdOverlay.Children.Add(args.Control);
        }
    }
}
