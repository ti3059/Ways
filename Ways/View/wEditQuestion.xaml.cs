using MySql.Data.MySqlClient;
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
    /// Logique d'interaction pour wEditQuestion.xaml
    /// </summary>
    public partial class wEditQuestion : Window
    {
        private string msg;
        Questions_Game qGame;
        List<Answer_Game> listAnswerGame;
        Questions_Orientation qOr;
        List<Answer_Orientation> listAnswerOrientation;

        public wEditQuestion(string choice)
        {
            InitializeComponent();
            msg = choice;
        }

        public wEditQuestion(string choice, Questions_Game q)
        {
            InitializeComponent();
            qGame = q;
            listAnswerGame = getAnswerByQuestionGameId(q.Id);
            setAnswerTBByAnswerTextList( new List<string> { listAnswerGame[0].Text.ToString(), listAnswerGame[1].Text.ToString(), listAnswerGame[2].Text.ToString(), listAnswerGame[3].Text.ToString() });
        }

        public wEditQuestion(string choice, Questions_Orientation q)
        {
            InitializeComponent();
            qOr = q;
            listAnswerOrientation = getAnswerByQuestionOrientationId(q.Id);
            List<string> listAnswer = new List<string>();
            setAnswerTBByAnswerTextList(new List<string> { listAnswerOrientation[0].Text.ToString(), listAnswerOrientation[1].Text.ToString(), listAnswerOrientation[2].Text.ToString(), listAnswerOrientation[3].Text.ToString() });
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            View.wAdmin pg = new View.wAdmin(msg);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(msg == "GAME")
            {
                if (qGame != null)
                {
                    Questions_Game questionGame = new Questions_Game();
                    questionGame.EditQuestionGame(qGame.Id, tbQuestion.Text.ToString());
                    Answer_Game answerGame = new Answer_Game();
                    answerGame.EditAnswerGame(listAnswerGame[0].Id, tbAnswerOne.Text.ToString(), listAnswerGame[0].Right);
                    answerGame.EditAnswerGame(listAnswerGame[1].Id, tbAnswerTwo.Text.ToString(), listAnswerGame[0].Right);
                    answerGame.EditAnswerGame(listAnswerGame[2].Id, tbAnswerThree.Text.ToString(), listAnswerGame[0].Right);
                    answerGame.EditAnswerGame(listAnswerGame[3].Id, tbAnswerFour.Text.ToString(), listAnswerGame[0].Right);
                }
                else
                {
                    Questions_Game questionGame = new Questions_Game();
                    questionGame.AddQuestionGame(tbQuestion.Text.ToString());
                    Answer_Game answerGame = new Answer_Game();
                    answerGame.AddAnswerGame(tbAnswerOne.Text.ToString(), true);
                    answerGame.AddAnswerGame(tbAnswerTwo.Text.ToString(), true);
                    answerGame.AddAnswerGame(tbAnswerThree.Text.ToString(), true);
                    answerGame.AddAnswerGame(tbAnswerFour.Text.ToString(), true);
                }
            }
            else
            {
                if (qOr != null)
                {
                    Questions_Orientation questionOrientation = new Questions_Orientation();
                    questionOrientation.EditQuestionOrientation(qGame.Id, tbQuestion.Text.ToString());
                    Answer_Orientation answerOrientation = new Answer_Orientation();
                    answerOrientation.EditAnswerOrientation(listAnswerOrientation[0].Id, tbAnswerOne.Text.ToString(), listAnswerOrientation[0].JobIndex);
                    answerOrientation.EditAnswerOrientation(listAnswerOrientation[1].Id, tbAnswerTwo.Text.ToString(), listAnswerOrientation[0].JobIndex);
                    answerOrientation.EditAnswerOrientation(listAnswerOrientation[2].Id, tbAnswerThree.Text.ToString(), listAnswerOrientation[0].JobIndex);
                    answerOrientation.EditAnswerOrientation(listAnswerOrientation[3].Id, tbAnswerFour.Text.ToString(), listAnswerOrientation[0].JobIndex);
                }
                else
                {
                    Questions_Orientation questionOrientation = new Questions_Orientation();
                    questionOrientation.AddQuestionOrientation(tbQuestion.Text.ToString());
                    Answer_Orientation answerOrientation = new Answer_Orientation();
                    answerOrientation.AddAnswerOrientation(tbAnswerOne.Text.ToString(), 1);
                    answerOrientation.AddAnswerOrientation(tbAnswerTwo.Text.ToString(), 2);
                    answerOrientation.AddAnswerOrientation(tbAnswerThree.Text.ToString(), 3);
                    answerOrientation.AddAnswerOrientation(tbAnswerFour.Text.ToString(), 4);
                }
            }
        }

        public List<Answer_Game> getAnswerByQuestionGameId(int questionGameId)
        {
            Answer_Game answerGame = new Answer_Game();
            return answerGame.SelectAnswerGameFromQuestionGameId(questionGameId);
        }
        public List<Answer_Orientation> getAnswerByQuestionOrientationId(int questionOrientationId)
        {
            Answer_Orientation answerOrientation = new Answer_Orientation();
            return answerOrientation.SelectAnswerOrientationFromQuestionOrientationId(questionOrientationId);
        }
        public void setAnswerTBByAnswerTextList(List<String> answerTextList)
        {
            tbAnswerOne.Text = answerTextList[0];
            tbAnswerTwo.Text = answerTextList[1];
            tbAnswerThree.Text = answerTextList[2];
            tbAnswerFour.Text = answerTextList[3];
        }
    }
}
