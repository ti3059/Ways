using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Logique d'interaction pour wResultOrientationCandidate.xaml
    /// </summary>
    public partial class wResultOrientationCandidate : Window
    {
        private Candidate candidate;
        public wResultOrientationCandidate(Candidate c)
        {
            InitializeComponent();
            Candidate = c;
            SetJobs();
        }

        public wResultOrientationCandidate()
        {
            InitializeComponent();
        }
        public Candidate Candidate { get => candidate; set => candidate = value; }

        private void SetJobs()
        {
            List<Job> lstCopyJobs = new List<Job>(vmStart.lstjobs); 
            string task = "";
            for (int w = 0; w < 2; w++)
            {
                int maxValue = 0;
                Job j = new Job();
                for (int i = 0; i < candidate.OrientationPoints.Count; i++)
                {
                    if (candidate.OrientationPoints[i] > maxValue)
                    {
                        j = lstCopyJobs[i];
                        maxValue = candidate.OrientationPoints[i];
                    }
                }

                foreach (string t in j.Tasks)
                {
                    task += t + "\n";
                }

                switch (w)
                {
                    case 0:
                        labelNameJob1.Content = j.Name;
                        labelDesJob1.Content = j.Des;
                        labelTasksJob1.Content = task;
                        break;
                    case 1:
                        labelNameJob2.Content = j.Name;
                        labelDesJob2.Content = j.Des;
                        labelTasksJob2.Content = task;
                        break;
                    case 2:
                        labelNameJob3.Content = j.Name;
                        labelDesJob3.Content = j.Des;
                        labelTasksJob3.Content = task;
                        break;
                }

                lstCopyJobs.Remove(j);
            }          

        }

        private void bDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            View.wTestMenu pg = new View.wTestMenu(candidate);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }
    }
}
