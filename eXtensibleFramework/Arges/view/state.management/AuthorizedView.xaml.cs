using System.Windows;
using System.Windows.Controls;

namespace Arges
{
    /// <summary>
    /// Interaction logic for AuthorizedView.xaml
    /// </summary>
    public partial class AuthorizedView : UserControl
    {
        public Control LocalView { get; set; }

        public AuthorizedView(UserControl localView)
        {

            InitializeComponent();
            LocalView = localView;
        }

        public AuthorizedView()
        {

            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ContentPlaceholder.Children.Add(LocalView);
        }
    }
}
