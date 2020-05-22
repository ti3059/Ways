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
    public partial class wAdminQuestion : Window
    {
        private string message;
        Questions_Game questionGame;
        Questions_Orientation questionOrientation;


        public wAdminQuestion(string msg)
        {
            InitializeComponent();
            message = msg;
        }

        public wAdminQuestion(string msg, Questions_Game q) : this(msg)
        {
            InitializeComponent();
            questionGame = q;
            lQuestionSubject.Text = q.Question;
        }

        public wAdminQuestion(string msg, Questions_Orientation q) : this(msg)
        {
            InitializeComponent();
            questionOrientation = q;
            lQuestionSubject.Text = q.Question;
        }



        private void bEdition_Click(object sender, RoutedEventArgs e)
        {
            View.wEditQuestion pg;
            if(message == "GAME")
            {
                pg = new View.wEditQuestion(message, questionGame);
            }
            else
            {
                pg = new View.wEditQuestion(message, questionOrientation);
            }
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();

        }

        private void bBarem_Click(object sender, RoutedEventArgs e)
        {
            if(message == "GAME")
            {
                View.wEditRightAnswer pg = new View.wEditRightAnswer(questionGame, message);
                pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                pg.Show();
                this.Close();
            }
            else
            {
                View.wEditJobAnswer pg = new View.wEditJobAnswer(questionOrientation, message);
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
                    if(message == "GAME")
                    {
                        Answer_Game aGame = new Answer_Game();
                        aGame.DeleteAnswersGameFromQuestionId(questionGame.Id);
                        Questions_Game qGame = new Questions_Game();
                        qGame.DeleteQuestionGame(questionGame.Id);
                    }
                    else
                    {
                        Answer_Orientation aOrientation = new Answer_Orientation();
                        aOrientation.DeleteAnswersOrientationFromQuestionId(questionOrientation.Id);
                        Questions_Orientation qOrientation = new Questions_Orientation();
                        qOrientation.DeleteQuestionOrientation(questionOrientation.Id);
                    }
                    MessageBox.Show("Question supprimée.", "My App");
                    //Mettre à jours la liste
                    View.wAdmin pg = new View.wAdmin(message);
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
            View.wAdmin pg = new View.wAdmin(message);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }
    }
}
