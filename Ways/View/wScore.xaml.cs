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
    public partial class wScore : Window
    {
        public wScore()
        {
            InitializeComponent();
            addCandidatesToListView();
        }

        public void addCandidatesToListView()
        {
            Candidate candidate = new Candidate();
            List<Candidate> lstCandidates = candidate.SelectAllCandidates();

            foreach (Candidate c in lstCandidates)
            {
                lvCandidate.Items.Add(c);
            }
            lvCandidate.Items.RemoveAt(0);
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
