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

namespace Ways.View
{
    /// <summary>
    /// Logique d'interaction pour wChoiceMenuAdmin.xaml
    /// </summary>
    public partial class wChoiceMenuAdmin : Window
    {
        public wChoiceMenuAdmin()
        {
            InitializeComponent();
        }

        private void btnGameManage_Click(object sender, RoutedEventArgs e)
        {
            wGameAdmin wGameAdmin = new wGameAdmin();
            wGameAdmin.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            wGameAdmin.Show();
            this.Close();
        }

        private void btnOrientationManage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
