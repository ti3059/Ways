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
            CurrentTest = "Orientation";
            TestOrientation = testOrientation;
            SetQuestions();
        }

        public wQuestion(Test_Game testGame) : this()
        {
            CurrentTest = "Game";
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
            lQuestionSubject.Text = TestOrientation.CurrentQuestion.Question;
            lAnswerOne.Content = TestOrientation.CurrentQuestion.Question[0];
            lAnswerTwo.Content = TestOrientation.CurrentQuestion.Question[1];
            lAnswerThree.Content = TestOrientation.CurrentQuestion.Question[2];
            lAnswerFour.Content = TestOrientation.CurrentQuestion.Question[3];
        }
    }
}
