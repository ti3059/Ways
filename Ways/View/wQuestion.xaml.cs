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
    /// Logique d'interaction pour wQuestion.xaml
    /// </summary>
    public partial class wQuestion : Window
    {
        private string currentTest;
        private Test_Orientation testOrientation;
        private Answer_Orientation answerOrientationSelected;
        private Test_Game testGame;
        private Answer_Game answerGameSelected;

        public wQuestion()
        {
            InitializeComponent();
        }
        public wQuestion(Test_Orientation testOrientation) : this()
        {
            CurrentTest = "ORIENTATION";
            TestOrientation = testOrientation;
            SetQuestions();
        }

        public wQuestion(Test_Game testGame) : this()
        {
            CurrentTest = "GAME";
            TestGame = testGame;
            SetQuestions();
        }

        public string CurrentTest { get => currentTest; set => currentTest = value; }
        public Test_Orientation TestOrientation { get => testOrientation; set => testOrientation = value; }
        public Answer_Orientation AnswerOrientationSelected { get => answerOrientationSelected; set => answerOrientationSelected = value; }
        public Test_Game TestGame { get => testGame; set => testGame = value; }
        public Answer_Game AnswerGameSelected { get => answerGameSelected; set => answerGameSelected = value; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentTest == "Orientation")
            {
                TestOrientation.Reply(AnswerOrientationSelected.JobIndex);
            }
            else
            {
                TestGame.Reply(AnswerGameSelected.Right);
            }
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectAnswer(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Answer_Orientation a = new Answer_Orientation();
            switch (button.Name)
            {
                case "lAnswerOne":
                    AnswerOrientationSelected = a.SelectAnswerOrientationFromQuestionOrientationId(TestOrientation.CurrentQuestion.Id)[0];
                    break;
                case "lAnswerTwo":
                    AnswerOrientationSelected = a.SelectAnswerOrientationFromQuestionOrientationId(TestOrientation.CurrentQuestion.Id)[1];
                    break;
                case "lAnswerThree":
                    AnswerOrientationSelected = a.SelectAnswerOrientationFromQuestionOrientationId(TestOrientation.CurrentQuestion.Id)[2];
                    break;
                case "lAnswerFour":
                    AnswerOrientationSelected = a.SelectAnswerOrientationFromQuestionOrientationId(TestOrientation.CurrentQuestion.Id)[3];
                    break;
            }
        }

        private void SetQuestions()
        {
            if(CurrentTest == "GAME")
            {
                Answer_Game aG = new Answer_Game();
                List<Answer_Game> lstAG = aG.SelectAnswerGameFromQuestionGameId(testGame.CurrentQuestion.Id);
                lQuestionSubject.Text = TestGame.CurrentQuestion.Question;
                lAnswerOne.Content = lstAG[0].Text;
                lAnswerTwo.Content = lstAG[1].Text;
                lAnswerThree.Content = lstAG[2].Text;
                lAnswerFour.Content = lstAG[3].Text;

                labelIndicator.Content = TestGame.CurrentQuestion.Id++ + " / " + lstAG.Count;

            }
            else
            {
                Answer_Orientation aOr = new Answer_Orientation();
                List<Answer_Orientation> lstOr = aOr.SelectAnswerOrientationFromQuestionOrientationId(TestOrientation.CurrentQuestion.Id);
                lQuestionSubject.Text = TestOrientation.CurrentQuestion.Question;
                lAnswerOne.Content = lstOr[0].Text;
                lAnswerTwo.Content = lstOr[1].Text;
                lAnswerThree.Content = lstOr[2].Text;
                lAnswerFour.Content = lstOr[3].Text;
                
                for(int i = 0; i < TestOrientation.Questions.Count; i++)
                {
                    if(TestOrientation.Questions[i] == TestOrientation.CurrentQuestion)
                    {
                        int temp = i + 1;
                        labelIndicator.Content = temp + " / " + TestOrientation.Questions.Count;
                    }
                }

            }

        }
    }
}
