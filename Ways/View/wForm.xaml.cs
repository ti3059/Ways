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
            Candidate.SetContacts(contactList);
            // pointe vers wScore
        }

        private void tbMailOne_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
