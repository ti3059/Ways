﻿using MySql.Data.MySqlClient;
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
            msg = choice;
            listAnswerGame = getAnswerByQuestionGameId(q.Id);
            setAnswerTBByAnswerTextList( new List<string> { listAnswerGame[0].Text.ToString(), listAnswerGame[1].Text.ToString(), listAnswerGame[2].Text.ToString(), listAnswerGame[3].Text.ToString() });
            tbQuestion.Text = q.Question;
        }

        public wEditQuestion(string choice, Questions_Orientation q)
        {
            InitializeComponent();
            qOr = q;
            msg = choice;
            listAnswerOrientation = getAnswerByQuestionOrientationId(q.Id);
            List<string> listAnswer = new List<string>();
            setAnswerTBByAnswerTextList(new List<string> { listAnswerOrientation[0].Text.ToString(), listAnswerOrientation[1].Text.ToString(), listAnswerOrientation[2].Text.ToString(), listAnswerOrientation[3].Text.ToString() });
            tbQuestion.Text = q.Question;
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
                    try
                    {
                        Questions_Game questionGame = new Questions_Game();
                        questionGame.EditQuestionGame(qGame.Id, tbQuestion.Text.ToString());
                        Answer_Game answerGame = new Answer_Game();
                        answerGame.EditTextAnswerGame(listAnswerGame[0].Id, tbAnswerOne.Text.ToString());
                        answerGame.EditTextAnswerGame(listAnswerGame[1].Id, tbAnswerTwo.Text.ToString());
                        answerGame.EditTextAnswerGame(listAnswerGame[2].Id, tbAnswerThree.Text.ToString());
                        answerGame.EditTextAnswerGame(listAnswerGame[3].Id, tbAnswerFour.Text.ToString());
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
                        Questions_Game questionGame = new Questions_Game();
                        long id = questionGame.AddQuestionGame(tbQuestion.Text.ToString());
                        Answer_Game answerGame = new Answer_Game();
                        answerGame.AddAnswerGame(tbAnswerOne.Text.ToString(), Convert.ToInt32(id), true);
                        answerGame.AddAnswerGame(tbAnswerTwo.Text.ToString(), Convert.ToInt32(id), true);
                        answerGame.AddAnswerGame(tbAnswerThree.Text.ToString(), Convert.ToInt32(id), true);
                        answerGame.AddAnswerGame(tbAnswerFour.Text.ToString(), Convert.ToInt32(id), true);
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
                if (qOr != null)
                {
                    try
                    {
                        Questions_Orientation questionOrientation = new Questions_Orientation();
                        questionOrientation.EditQuestionOrientation(qGame.Id, tbQuestion.Text.ToString());
                        Answer_Orientation answerOrientation = new Answer_Orientation();
                        answerOrientation.EditTextAnswerOrientation(listAnswerOrientation[0].Id, tbAnswerOne.Text.ToString());
                        answerOrientation.EditTextAnswerOrientation(listAnswerOrientation[1].Id, tbAnswerTwo.Text.ToString());
                        answerOrientation.EditTextAnswerOrientation(listAnswerOrientation[2].Id, tbAnswerThree.Text.ToString());
                        answerOrientation.EditTextAnswerOrientation(listAnswerOrientation[3].Id, tbAnswerFour.Text.ToString());
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
                        Questions_Orientation questionOrientation = new Questions_Orientation();
                        long id = questionOrientation.AddQuestionOrientation(tbQuestion.Text.ToString());
                        Answer_Orientation answerOrientation = new Answer_Orientation();
                        answerOrientation.AddAnswerOrientation(tbAnswerOne.Text.ToString(), Convert.ToInt32(id), 1);
                        answerOrientation.AddAnswerOrientation(tbAnswerTwo.Text.ToString(), Convert.ToInt32(id), 2);
                        answerOrientation.AddAnswerOrientation(tbAnswerThree.Text.ToString(), Convert.ToInt32(id), 3);
                        answerOrientation.AddAnswerOrientation(tbAnswerFour.Text.ToString(), Convert.ToInt32(id), 4);
                        MessageBox.Show("Ajout effectué avec succès");
                    }
                    catch
                    {
                        MessageBox.Show("Attention, impossible d'ajouter la question");
                    }
                }
            }
            wAdmin wChoiceMenuAdmin = new wAdmin(msg);
            wChoiceMenuAdmin.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            wChoiceMenuAdmin.Show();
            this.Close();
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
