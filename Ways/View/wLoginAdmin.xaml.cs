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
    /// Logique d'interaction pour wLoginAdmin.xaml
    /// </summary>
    public partial class wLoginAdmin : Window
    {
        public wLoginAdmin()
        {
            InitializeComponent();
        }

        private void btnAdministrateur_Click(object sender, RoutedEventArgs e)
        {
            if ((Model.Admin.Login == tbLogin.Text) && (Model.Admin.Password == tbPassword.Password.ToString()))
            {
                wChoiceMenuAdmin wChoiceMenuAdmin = new wChoiceMenuAdmin();
                wChoiceMenuAdmin.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                wChoiceMenuAdmin.Show();
                this.Close();

            }
            else
            {
                lblError.Visibility = Visibility;
            }
        }
    }
}
