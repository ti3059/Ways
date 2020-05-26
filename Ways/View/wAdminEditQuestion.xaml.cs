using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
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
    public partial class wAdminEditQuestion : Window
    {
        private string currentTest;
        Questions_Game questionGame;
        List<Answer_Game> listAnswerGame;
        Questions_Orientation questionOrientation;
        List<Answer_Orientation> listAnswerOrientation;

        public wAdminEditQuestion(string msg)
        {
            InitializeComponent();
            currentTest = msg;
        }

        public wAdminEditQuestion(string msg, Questions_Game currentQuestionGame)
        {
            InitializeComponent();
            questionGame = currentQuestionGame;
            currentTest = msg;
            listAnswerGame = getAnswerByQuestionGameId(currentQuestionGame.Id);
            setAnswerTBByAnswerTextList( new List<string> { listAnswerGame[0].Text.ToString(), listAnswerGame[1].Text.ToString(), listAnswerGame[2].Text.ToString(), listAnswerGame[3].Text.ToString() });
            tbQuestion.Text = currentQuestionGame.Question;
        }

        public wAdminEditQuestion(string msg, Questions_Orientation q)
        {
            InitializeComponent();
            questionOrientation = q;
            currentTest = msg;
            listAnswerOrientation = getAnswerByQuestionOrientationId(q.Id);
            List<string> listAnswer = new List<string>();
            setAnswerTBByAnswerTextList(new List<string> { listAnswerOrientation[0].Text.ToString(), listAnswerOrientation[1].Text.ToString(), listAnswerOrientation[2].Text.ToString(), listAnswerOrientation[3].Text.ToString() });
            tbQuestion.Text = q.Question;
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            View.wAdminCurrentTest pg = new View.wAdminCurrentTest(currentTest);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(currentTest == "GAME")
            {
                if (questionGame != null)
                {
                    try
                    {
                        Questions_Game editQuestionGame = new Questions_Game();
                        editQuestionGame.EditQuestionGame(questionGame.Id, tbQuestion.Text.ToString());
                        Answer_Game editAnswerGame = new Answer_Game();
                        editAnswerGame.EditTextAnswerGame(listAnswerGame[0].Id, tbAnswerOne.Text.ToString());
                        editAnswerGame.EditTextAnswerGame(listAnswerGame[1].Id, tbAnswerTwo.Text.ToString());
                        editAnswerGame.EditTextAnswerGame(listAnswerGame[2].Id, tbAnswerThree.Text.ToString());
                        editAnswerGame.EditTextAnswerGame(listAnswerGame[3].Id, tbAnswerFour.Text.ToString());
                        MessageBox.Show("Modification effectué avec succès");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Attention, impossible de modifier la question");
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    try
                    {
                        Questions_Game addQuestionGame = new Questions_Game();
                        long id = addQuestionGame.AddQuestionGame(tbQuestion.Text.ToString());
                        Answer_Game addAnswerGame = new Answer_Game();
                        addAnswerGame.AddAnswerGame(tbAnswerOne.Text.ToString(), Convert.ToInt32(id), true);
                        addAnswerGame.AddAnswerGame(tbAnswerTwo.Text.ToString(), Convert.ToInt32(id), true);
                        addAnswerGame.AddAnswerGame(tbAnswerThree.Text.ToString(), Convert.ToInt32(id), true);
                        addAnswerGame.AddAnswerGame(tbAnswerFour.Text.ToString(), Convert.ToInt32(id), true);
                        MessageBox.Show("Ajout effectué avec succès");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Attention, impossible d'ajouter la question");
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                if (questionOrientation != null)
                {
                    try
                    {
                        Questions_Orientation editQuestionOrientation = new Questions_Orientation();
                        editQuestionOrientation.EditQuestionOrientation(questionOrientation.Id, tbQuestion.Text.ToString());
                        Answer_Orientation editAnswerOrientation = new Answer_Orientation();
                        editAnswerOrientation.EditTextAnswerOrientation(listAnswerOrientation[0].Id, tbAnswerOne.Text.ToString());
                        editAnswerOrientation.EditTextAnswerOrientation(listAnswerOrientation[1].Id, tbAnswerTwo.Text.ToString());
                        editAnswerOrientation.EditTextAnswerOrientation(listAnswerOrientation[2].Id, tbAnswerThree.Text.ToString());
                        editAnswerOrientation.EditTextAnswerOrientation(listAnswerOrientation[3].Id, tbAnswerFour.Text.ToString());
                        MessageBox.Show("Modification effectué avec succès");
                    }
                    catch
                    {
                        MessageBox.Show("Attention, impossible de modifier la question");
                    }

                }
                else
                {
                    try
                    {
                        Questions_Orientation addQuestionOrientation = new Questions_Orientation();
                        long id = addQuestionOrientation.AddQuestionOrientation(tbQuestion.Text.ToString());
                        Answer_Orientation addAnswerOrientation = new Answer_Orientation();
                        addAnswerOrientation.AddAnswerOrientation(tbAnswerOne.Text.ToString(), Convert.ToInt32(id), 1);
                        addAnswerOrientation.AddAnswerOrientation(tbAnswerTwo.Text.ToString(), Convert.ToInt32(id), 2);
                        addAnswerOrientation.AddAnswerOrientation(tbAnswerThree.Text.ToString(), Convert.ToInt32(id), 3);
                        addAnswerOrientation.AddAnswerOrientation(tbAnswerFour.Text.ToString(), Convert.ToInt32(id), 4);
                        MessageBox.Show("Ajout effectué avec succès");
                    }
                    catch
                    {
                        MessageBox.Show("Attention, impossible d'ajouter la question");
                    }
                }
            }
            wAdminCurrentTest pg = new wAdminCurrentTest(currentTest);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }

        public List<Answer_Game> getAnswerByQuestionGameId(int questionGameId)
        {
            Answer_Game getAnswerGame = new Answer_Game();
            return getAnswerGame.SelectAnswerGameFromQuestionGameId(questionGameId);
        }
        public List<Answer_Orientation> getAnswerByQuestionOrientationId(int questionOrientationId)
        {
            Answer_Orientation getAnswerOrientation = new Answer_Orientation();
            return getAnswerOrientation.SelectAnswerOrientationFromQuestionOrientationId(questionOrientationId);
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
