using MySql.Data.MySqlClient;
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
using Ways.ViewModel;

namespace Ways.View
{
    /// <summary>
    /// Logique d'interaction pour wScore.xaml
    /// </summary>
    public partial class wCandidateResultGame : Window
    {
        private Candidate candidate;
        public wCandidateResultGame(Candidate currentCandidate)
        {
            InitializeComponent();
            Candidate = currentCandidate;
            addCandidatesToListView();
        }
        public Candidate Candidate { get => candidate; set => candidate = value; }

        public void addCandidatesToListView()
        {
            Candidate newCandidate = new Candidate();
            List<Candidate> lstCandidates = newCandidate.SelectAllCandidates();

            foreach (Candidate candidateInList in lstCandidates)
            {
                lvCandidate.Items.Add(candidateInList);
            }
            lvCandidate.Items.RemoveAt(0);
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            View.wCandidatMenu pg = new View.wCandidatMenu(candidate);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }

        private void btnForm_Click(object sender, RoutedEventArgs e)
        {
            View.wEditMail pg = new View.wEditMail("CONTACT", Candidate);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }
    }
}
