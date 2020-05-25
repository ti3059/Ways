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
    /// Logique d'interaction pour wEditRightAnswer.xaml
    /// </summary>
    public partial class wEditRightAnswer : Window
    {
        private Questions_Game questionSelected;
        private List<Answer_Game> lstAnswer = new List<Answer_Game>();
        private string currentTest;


        public wEditRightAnswer(Questions_Game currentQuestionGame, string msg)
        {
            InitializeComponent();
            questionSelected = currentQuestionGame;
            currentTest = msg;
            Answer_Game newAnswerGame = new Answer_Game();
            lstAnswer = newAnswerGame.SelectAnswerGameFromQuestionGameId(questionSelected.Id);
            setAnswers();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Answer_Game editAnswerGame = new Answer_Game();
                editAnswerGame.EditRightAnswerGame(lstAnswer[0].Id, (bool)chbAnswerOne.IsChecked);
                editAnswerGame.EditRightAnswerGame(lstAnswer[1].Id, (bool)chbAnswerTwo.IsChecked);
                editAnswerGame.EditRightAnswerGame(lstAnswer[2].Id, (bool)chbAnswerThree.IsChecked);
                editAnswerGame.EditRightAnswerGame(lstAnswer[3].Id, (bool)chbAnswerFour.IsChecked);
                MessageBox.Show("Modification effectuée");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification de la question");   
            }
            View.wAdminQuestion pg = new View.wAdminQuestion(currentTest, questionSelected);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }

        private void setAnswers()
        {
            lQuestionSubject.Text = questionSelected.Question;
            lAnswerOne.Text = lstAnswer[0].Text;
            lAnswerTwo.Text = lstAnswer[1].Text;
            lAnswerThree.Text = lstAnswer[2].Text;
            lAnswerFour.Text = lstAnswer[3].Text;

            chbAnswerOne.IsChecked = lstAnswer[0].Right;
            chbAnswerTwo.IsChecked = lstAnswer[1].Right;
            chbAnswerThree.IsChecked = lstAnswer[2].Right;
            chbAnswerFour.IsChecked = lstAnswer[3].Right;

        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            View.wAdminQuestion pg = new View.wAdminQuestion(currentTest);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }
    }
}
