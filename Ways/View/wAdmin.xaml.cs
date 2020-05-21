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
    /// Logique d'interaction pour wGameAdmin.xaml
    /// </summary>
    public partial class wAdmin : Window
    {
        private string msg;
        public wAdmin(string choice)
        {
            InitializeComponent();
            msg = choice;
            if(choice == "GAME")
            {
                addQuestionGameToListView();
            }
            else
            {
                addQuestionOrientationToListView();
            }
        }

        public void addQuestionGameToListView()
        {
            foreach(Questions_Game q in vmStart.lstQustionsGames)
            {
                lvAdmin.Items.Add(q);
            }
        }

        public void addQuestionOrientationToListView()
        {
            foreach (Questions_Orientation q in vmStart.lstQuestionsOrientation)
            {
                lvAdmin.Items.Add(q);
            }
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            View.wChoiceMenuAdmin pgChoice = new View.wChoiceMenuAdmin();
            pgChoice.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pgChoice.Show();
            this.Close();
        }

        private void listView_Click(object sender, MouseButtonEventArgs e)
        {       
            if(lvAdmin.SelectedValue != null)
            {
                if (msg == "GAME")
                {
                    Questions_Game qSelected = (Questions_Game)lvAdmin.SelectedItems[0];
                    View.wAdminQuestion pgAdminQuestion = new View.wAdminQuestion(msg, qSelected);
                    pgAdminQuestion.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    pgAdminQuestion.Show();
                    this.Close();
                }
                else
                {
                    Questions_Orientation qSelected = (Questions_Orientation)lvAdmin.SelectedItems[0];
                    View.wAdminQuestion pgAdminQuestion = new View.wAdminQuestion(msg, qSelected);
                    pgAdminQuestion.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    pgAdminQuestion.Show();
                    this.Close();
                }
            }
        }

        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            
                View.wEditQuestion pgEditQuestion = new View.wEditQuestion(msg);
                pgEditQuestion.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                pgEditQuestion.Show();
                this.Close();

        }
    }
}
