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
using Ways.Model;

namespace Ways.View
{
    /// <summary>
    /// Logique d'interaction pour wInfoCandidate.xaml
    /// </summary>
    public partial class wInfoCandidate : Window
    {
        private Candidate candidate;
        private bool control = false;
        public wInfoCandidate(Candidate c)
        {
            InitializeComponent();
            candidate = c;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            List<string> lstString = new List<string>();
            if((tb1.Text == "") || (tb2.Text == "") || (tb3.Text == "") || (tb4.Text == "") || (tb5.Text == "") || (tb6.Text == "") || (tb7.Text == "") || (tb8.Text == "") || (tb9.Text == "") || (tb10.Text == ""))
            {
                MessageBox.Show("Veuillez renseigner tous les champs");
            }
            else
            {
                lstString.Add(tb1.Text);
                lstString.Add(tb2.Text);
                lstString.Add(tb3.Text);
                lstString.Add(tb4.Text);
                lstString.Add(tb5.Text);
                lstString.Add(tb6.Text);
                lstString.Add(tb7.Text);
                lstString.Add(tb8.Text);
                lstString.Add(tb9.Text);
                lstString.Add(tb10.Text);


                candidate.LstInfoCandidate = lstString;

                candidate.SaveInfoInBase();

                View.wTestMenu pg = new View.wTestMenu(candidate.Test_Game.Candidate);
                pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                pg.Show();
                this.Close();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            View.wTestMenu pg = new View.wTestMenu(candidate);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }
    }
}
