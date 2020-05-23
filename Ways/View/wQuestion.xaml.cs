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
        private Test_Orientation testOrientation;
        private Answer_Orientation answerOrientationSelected;

        public wQuestion()
        {
            InitializeComponent();
        }
        public wQuestion(Test_Orientation testOrientation)
        {
            InitializeComponent();
            TestOrientation = testOrientation;
        }

        public Test_Orientation TestOrientation { get => testOrientation; set => testOrientation = value; }
        public Answer_Orientation AnswerOrientationSelected { get => answerOrientationSelected; set => answerOrientationSelected = value; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestOrientation.Reply(AnswerOrientationSelected.JobIndex);
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectAnswer(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            switch (button.Name)
            {
                case "lAnswerOne":
                    AnswerOrientationSelected = TestOrientation.CurrentQuestion.SelectQuestionsOrientation().[0];
                    break;
                case "lAnswerTwo":
                    AnswerOrientationSelected = TestOrientation.CurrentQuestion.SelectQuestionsOrientation().[1];
                    break;
                case "lAnswerThree":
                    AnswerOrientationSelected = TestOrientation.CurrentQuestion.SelectQuestionsOrientation().[2];
                    break;
                case "lAnswerFour":
                    AnswerOrientationSelected = TestOrientation.CurrentQuestion.SelectQuestionsOrientation().[3];
                    break;
            }
        }
    }
}
