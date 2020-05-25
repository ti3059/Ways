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
        private string currentTest;
        public wAdmin(string msg)
        {
            InitializeComponent();
            currentTest = msg;
            if(currentTest == "GAME")
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
            vmStart.getQuestionsGame();
            foreach(Questions_Game questionGameInList in vmStart.lstQustionsGames)
            {
                lvAdmin.Items.Add(questionGameInList);
            }
            lvAdmin.Items.RemoveAt(0);
        }

        public void addQuestionOrientationToListView()
        {
            vmStart.getQuestionsOrientation();
            foreach (Questions_Orientation questionOrientationInList in vmStart.lstQuestionsOrientation)
            {
                lvAdmin.Items.Add(questionOrientationInList);
            }
            lvAdmin.Items.RemoveAt(0);
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            View.wChoiceMenuAdmin pg = new View.wChoiceMenuAdmin();
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }

        private void listView_Click(object sender, MouseButtonEventArgs e)
        {       
            if(lvAdmin.SelectedValue != null)
            {
                if (currentTest == "GAME")
                {
                    Questions_Game questionGameSelected = (Questions_Game)lvAdmin.SelectedItems[0];
                    View.wAdminQuestion pgAdminQuestion = new View.wAdminQuestion(currentTest, questionGameSelected);
                    pgAdminQuestion.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    pgAdminQuestion.Show();
                    this.Close();
                }
                else
                {
                    Questions_Orientation questionOrientationSelected = (Questions_Orientation)lvAdmin.SelectedItems[0];
                    View.wAdminQuestion pgAdminQuestion = new View.wAdminQuestion(currentTest, questionOrientationSelected);
                    pgAdminQuestion.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    pgAdminQuestion.Show();
                    this.Close();
                }
            }
        }

        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            
                View.wEditQuestion pgEditQuestion = new View.wEditQuestion(currentTest);
                pgEditQuestion.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                pgEditQuestion.Show();
                this.Close();

        }
    }
}
