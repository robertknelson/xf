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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
