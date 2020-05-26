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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ways.Model;

namespace Ways.View
{
    /// <summary>
    /// Logique d'interaction pour wAdminQuestion.xaml
    /// </summary>
    public partial class wAdminQuestionSelected : Window
    {
        private string currentTest;
        Questions_Game questionGame;
        Questions_Orientation questionOrientation;


        public wAdminQuestionSelected(string msg)
        {
            InitializeComponent();
            currentTest = msg;
        }

        public wAdminQuestionSelected(string msg, Questions_Game currentQuestionGame) : this(msg)
        {
            InitializeComponent();
            questionGame = currentQuestionGame;
            lQuestionSubject.Text = currentQuestionGame.Question;
        }

        public wAdminQuestionSelected(string msg, Questions_Orientation currentQuestionOrientation) : this(msg)
        {
            InitializeComponent();
            questionOrientation = currentQuestionOrientation;
            lQuestionSubject.Text = questionOrientation.Question;
        }



        private void bEdition_Click(object sender, RoutedEventArgs e)
        {
            View.wAdminEditQuestion pg;
            if(currentTest == "GAME")
            {
                pg = new View.wAdminEditQuestion(currentTest, questionGame);
            }
            else
            {
                pg = new View.wAdminEditQuestion(currentTest, questionOrientation);
            }
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();

        }

        private void bBarem_Click(object sender, RoutedEventArgs e)
        {
            if(currentTest == "GAME")
            {
                View.wEditRightAnswer pg = new View.wEditRightAnswer(questionGame, currentTest);
                pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                pg.Show();
                this.Close();
            }
            else
            {
                View.wAdminEditRatingOrientation pg = new View.wAdminEditRatingOrientation(questionOrientation, currentTest);
                pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                pg.Show();
                this.Close();
            }

        }

        private void bSuppression_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sure de vouloir supprimer la question ?", "My App", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if(currentTest == "GAME")
                    {
                        Answer_Game newAnswerGame = new Answer_Game();
                        newAnswerGame.DeleteAnswersGameFromQuestionId(questionGame.Id);
                        Questions_Game newQuestionGame = new Questions_Game();
                        newQuestionGame.DeleteQuestionGame(questionGame.Id);
                    }
                    else
                    {
                        Answer_Orientation newAnswerOrientation = new Answer_Orientation();
                        newAnswerOrientation.DeleteAnswersOrientationFromQuestionId(questionOrientation.Id);
                        Questions_Orientation newQuestionOrientation = new Questions_Orientation();
                        newQuestionOrientation.DeleteQuestionOrientation(questionOrientation.Id);
                    }
                    MessageBox.Show("Question supprimée.", "My App");
                    //Mettre à jours la liste
                    View.wAdminQuestionSelected pg = new View.wAdminQuestionSelected(currentTest);
                    pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    pg.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }

        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            View.wAdminCurrentTest pg = new View.wAdminCurrentTest(currentTest);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }
    }
}
