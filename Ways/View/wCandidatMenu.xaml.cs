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
    /// Logique d'interaction pour wAtestMenu.xaml
    /// </summary>
    public partial class wCandidatMenu : Window
    {
        private Candidate candidate;

        public wCandidatMenu(Candidate currentCandidate)
        {
            InitializeComponent();
            candidate = currentCandidate;
            SetContentButton();
        }

        private void bGame_Click(object sender, RoutedEventArgs e)
        {
            if (candidate.Test_Game.CurrentQuestion == null)
            {
                if(candidate.Test_Orientation.CurrentQuestion == null)
                {
                    if (candidate.Info)
                    {
                        View.wCandidateResultGame pg = new View.wCandidateResultGame(candidate);
                        pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        pg.Show();
                        this.Close();
                    }
                    else
                    {
                        View.wCandidateInformations pg = new View.wCandidateInformations(candidate);
                        pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        pg.Show();
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Terminer le test d'orientation pour accéder au tableau des scores.");
                }
            }
            else
            {
                View.wCandidateCurrentQuestion pg = new View.wCandidateCurrentQuestion(candidate, "GAME");
                pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                pg.Show();
                this.Close();
            }
        }

        private void ClickOrientation(object sender, RoutedEventArgs e)
        {
            if(candidate.Test_Orientation.CurrentQuestion == null)
            {
                View.wCandidateResultOrientation pg = new View.wCandidateResultOrientation(candidate);
                pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                pg.Show();
                this.Close();
            }
            else
            {
                View.wCandidateCurrentQuestion pg = new View.wCandidateCurrentQuestion(candidate, "ORIENTATION");
                pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                pg.Show();
                this.Close();
            }

        }

        private void SetContentButton()
        {
            if(candidate.Test_Orientation.CurrentQuestion == null)
            {
                bOrientation.Content = "Résultat du test d'orientation";
            }
            else
            {
                bOrientation.Content = "Test Orientation";
            }

            if(candidate.Test_Game.CurrentQuestion == null)
            {
                bGame.Content = "Tableau des scores";
            }
            else
            {
                bGame.Content = "Jeu";
            }
        }

        private void bDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            Ways.MainWindow pg = new Ways.MainWindow();
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }
    }
}
