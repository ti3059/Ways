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
    public partial class wLoginCandidate : Window
    {
        public wLoginCandidate()
        {
            InitializeComponent();
        }

        private void btnCandidate_Click(object sender, RoutedEventArgs e)
        {
            Model.Candidate c = new Model.Candidate(vmStart.lstjobs);
            c.Surname = tbLogin.Text;
            View.wTestMenu pg = new View.wTestMenu(c);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }
    }
}
