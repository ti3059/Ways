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
    /// Logique d'interaction pour wForm.xaml
    /// </summary>
    public partial class wForm : Window
    {
        private Candidate candidate;
        public wForm(Candidate candidate)
        {
            InitializeComponent();
            Candidate = candidate;
            if(Candidate.Contact)
            {
                bValidate.IsEnabled = false;
            }
        }
        public Candidate Candidate { get => candidate; set => candidate = value; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<String> contactList = new List<string>();
            if (tbMailOne.Text != "Exemple@mail.fr" && tbMailOne.Text != "")
            {
                contactList.Add(tbMailOne.Text);
            }
            if (tbMailTwo.Text != "Exemple@mail.fr" && tbMailTwo.Text != "" && contactList.Contains(tbMailTwo.Text) != true)
            {
                contactList.Add(tbMailTwo.Text);
            }
            if (tbMailThree.Text != "Exemple@mail.fr" && tbMailThree.Text != "" && contactList.Contains(tbMailThree.Text) != true)
            {
                contactList.Add(tbMailThree.Text);
            }
            if (tbMailFour.Text != "Exemple@mail.fr" && tbMailFour.Text != "" && contactList.Contains(tbMailFour.Text) != true)
            {
                contactList.Add(tbMailFour.Text);
            }
            try
            {
                Candidate.SetContacts(contactList);
                MessageBox.Show("Score augmenté");
                View.wScore pg = new View.wScore(candidate);
                pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                pg.Show();
                this.Close();
                // pointe vers wScore
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la sauvegarde des contacts");
            }
        }

        private void tbMailOne_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            View.wScore pg = new View.wScore(candidate);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }
    }
}
