﻿using System;
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
    /// Logique d'interaction pour wQuestion.xaml
    /// </summary>
    public partial class wCandidateCurrentQuestion : Window
    {
        private string currentTest;
        private Answer_Orientation answerOrientationSelected;
        private Answer_Game answerGameSelected;
        private Candidate candidate;


        public wCandidateCurrentQuestion()
        {
            InitializeComponent();
        }

        public wCandidateCurrentQuestion(Candidate currentCandidate, string msg) : this()
        {
            CurrentTest = msg;
            Candidate = currentCandidate;
            SetQuestions();
        }

        public string CurrentTest { get => currentTest; set => currentTest = value; }
        public Answer_Orientation AnswerOrientationSelected { get => answerOrientationSelected; set => answerOrientationSelected = value; }
        public Answer_Game AnswerGameSelected { get => answerGameSelected; set => answerGameSelected = value; }
        public Candidate Candidate { get => candidate; set => candidate = value; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentTest == "ORIENTATION")
            {
                candidate.Test_Orientation.Reply(AnswerOrientationSelected.JobIndex);
                if(candidate.Test_Orientation.CurrentQuestion == null)
                {
                    MessageBox.Show("Fin des questions");
                    View.wCandidatMenu pg = new View.wCandidatMenu(candidate);
                    pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    pg.Show();
                    this.Close();
                }
                else
                {
                    View.wCandidateCurrentQuestion pg = new View.wCandidateCurrentQuestion(candidate, currentTest);
                    pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    pg.Show();
                    this.Close();
                }
            }
            else
            {
                candidate.Test_Game.Reply(AnswerGameSelected.Right);
                if (candidate.Test_Game.CurrentQuestion == null)
                {
                    MessageBox.Show("Fin des questions");
                    View.wCandidateInformations pg = new View.wCandidateInformations(candidate.Test_Game.Candidate);
                    pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    pg.Show();
                    this.Close();
                }
                else
                {
                    View.wCandidateCurrentQuestion pg = new View.wCandidateCurrentQuestion(candidate, currentTest);
                    pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    pg.Show();
                    this.Close();
                }
            }

        }

        private void SelectAnswer(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Answer_Orientation newAnswerOrientation = new Answer_Orientation();
            Answer_Game newAnswerGame = new Answer_Game();

            if(currentTest == "GAME")
            {
                switch (button.Name)
                {
                    case "lAnswerOne":
                        answerGameSelected = newAnswerGame.SelectAnswerGameFromQuestionGameId(candidate.Test_Game.CurrentQuestion.Id)[0];
                        break;
                    case "lAnswerTwo":
                        answerGameSelected = newAnswerGame.SelectAnswerGameFromQuestionGameId(candidate.Test_Game.CurrentQuestion.Id)[1];
                        break;
                    case "lAnswerThree":
                        answerGameSelected = newAnswerGame.SelectAnswerGameFromQuestionGameId(candidate.Test_Game.CurrentQuestion.Id)[2];
                        break;
                    case "lAnswerFour":
                        answerGameSelected = newAnswerGame.SelectAnswerGameFromQuestionGameId(candidate.Test_Game.CurrentQuestion.Id)[3];
                        break;
                }
            }
            else
            {
                switch (button.Name)
                {
                    case "lAnswerOne":
                        AnswerOrientationSelected = newAnswerOrientation.SelectAnswerOrientationFromQuestionOrientationId(candidate.Test_Orientation.CurrentQuestion.Id)[0];
                        break;
                    case "lAnswerTwo":
                        AnswerOrientationSelected = newAnswerOrientation.SelectAnswerOrientationFromQuestionOrientationId(candidate.Test_Orientation.CurrentQuestion.Id)[1];
                        break;
                    case "lAnswerThree":
                        AnswerOrientationSelected = newAnswerOrientation.SelectAnswerOrientationFromQuestionOrientationId(candidate.Test_Orientation.CurrentQuestion.Id)[2];
                        break;
                    case "lAnswerFour":
                        AnswerOrientationSelected = newAnswerOrientation.SelectAnswerOrientationFromQuestionOrientationId(candidate.Test_Orientation.CurrentQuestion.Id)[3];
                        break;
                }
            }

        }

        private void SetQuestions()
        {
            if(CurrentTest == "GAME")
            {
                Answer_Game newAnswerGame = new Answer_Game();
                List<Answer_Game> lstAnswerGame = newAnswerGame.SelectAnswerGameFromQuestionGameId(candidate.Test_Game.CurrentQuestion.Id);
                lQuestionSubject.Text = "Question : " + candidate.Test_Game.CurrentQuestion.Question;
                lAnswerOne.Content = lstAnswerGame[0].Text;
                lAnswerTwo.Content = lstAnswerGame[1].Text;
                lAnswerThree.Content = lstAnswerGame[2].Text;
                lAnswerFour.Content = lstAnswerGame[3].Text;

                for (int i = 0; i < candidate.Test_Game.Questions.Count; i++)
                {
                    if (candidate.Test_Game.Questions[i] == candidate.Test_Game.CurrentQuestion)
                    {
                        int temp = i + 1;
                        labelIndicator.Content = temp + " / " + candidate.Test_Game.Questions.Count;
                    }
                }

            }
            else
            {
                Answer_Orientation newAOrientation = new Answer_Orientation();
                List<Answer_Orientation> lstAnswerOrientation = newAOrientation.SelectAnswerOrientationFromQuestionOrientationId(candidate.Test_Orientation.CurrentQuestion.Id);
                lQuestionSubject.Text = "Question : " + candidate.Test_Orientation.CurrentQuestion.Question;
                lAnswerOne.Content = lstAnswerOrientation[0].Text;
                lAnswerTwo.Content = lstAnswerOrientation[1].Text;
                lAnswerThree.Content = lstAnswerOrientation[2].Text;
                lAnswerFour.Content = lstAnswerOrientation[3].Text;
                
                for(int i = 0; i < candidate.Test_Orientation.Questions.Count; i++)
                {
                    if(candidate.Test_Orientation.Questions[i] == candidate.Test_Orientation.CurrentQuestion)
                    {
                        int temp = i + 1;
                        labelIndicator.Content = temp + " / " + candidate.Test_Orientation.Questions.Count;
                    }
                }

            }

        }
    }
}
