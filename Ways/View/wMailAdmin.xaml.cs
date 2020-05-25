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
using Ways.ViewModel;

namespace Ways.View
{
    /// <summary>
    /// Logique d'interaction pour wMailAdmin.xaml
    /// </summary>
    public partial class wMailAdmin : Window
    {
        public wMailAdmin()
        {
            InitializeComponent();
            tbMail.Text = vmStart.emailAdmin;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            View.wChoiceMenuAdmin pg = new View.wChoiceMenuAdmin();
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }

        private void btnCandidate_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if(tbMail.Text == "")
            {
                MessageBox.Show("Veuillez renseigner un mail");
            }
            else
            {
                vmStart.emailAdmin = tbMail.Text;
                View.wChoiceMenuAdmin pg = new View.wChoiceMenuAdmin();
                pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                pg.Show();
                this.Close();
            }

        }
    }
}
