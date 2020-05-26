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
    /// Logique d'interaction pour wLoginCandidate.xaml
    /// </summary>
    public partial class wCandidateLogin : Window
    {
        public wCandidateLogin()
        {
            InitializeComponent();
        }

        private void btnCandidate_Click(object sender, RoutedEventArgs e)
        {
            if((tbLogin.Text == "Login") || (tbLogin.Text == ""))
            {
                MessageBox.Show("Veuillez renseigner un nom d'utilisateur");
            }
            else
            {
                Model.Candidate candidate = new Model.Candidate(vmStart.lstjobs);
                candidate.Surname = tbLogin.Text;
                View.wCandidatMenu pg = new View.wCandidatMenu(candidate);
                pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                pg.Show();
                this.Close();
            }

        }
    }
}
