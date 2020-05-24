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
    public partial class wTestMenu : Window
    {
        private Candidate candidate;

        public wTestMenu(Candidate c)
        {
            InitializeComponent();
            candidate = c;
            SetContentButton();
            
        }

        private void bGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClickOrientation(object sender, RoutedEventArgs e)
        {
            if(candidate.Test_Orientation.CurrentQuestion == null)
            {
                //End game
                MessageBox.Show("Fin du jeu");
            }
            else
            {
                View.wQuestion pg = new View.wQuestion(candidate, "ORIENTATION");
                pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                pg.Show();
                this.Close();
            }

        }

        private void SetContentButton()
        {
            if(candidate.Test_Orientation.CurrentQuestion == null)
            {
                bOrientation.Content = "Résultat du test l'orientation";
            }
            else
            {
                bOrientation.Content = "Test Orientation";
            }
        }


    }
}
