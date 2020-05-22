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
using Ways.ViewModel;

namespace Ways.View
{
    /// <summary>
    /// Logique d'interaction pour wEditJobAnswer .xaml
    /// </summary>
    public partial class wEditJobAnswer : Window
    {
        private Questions_Orientation questionSelected;
        private List<Answer_Orientation> lstAnswer = new List<Answer_Orientation>();
        private string message;

        public wEditJobAnswer(Questions_Orientation question, string msg)
        {
            InitializeComponent();
            questionSelected = question;
            message = msg;
            Answer_Orientation answerO = new Answer_Orientation();
            lstAnswer = answerO.SelectAnswerOrientationFromQuestionOrientationId(questionSelected.Id);
            setAnswers();
        }

        public wEditJobAnswer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Answer_Orientation answer = new Answer_Orientation();
            answer.EditAnswerOrientation(lstAnswer[0].Id, lstAnswer[0].Text, cbAnswerJobOne.SelectedIndex);
            answer.EditAnswerOrientation(lstAnswer[1].Id, lstAnswer[1].Text, cbAnswerJobTwo.SelectedIndex);
            answer.EditAnswerOrientation(lstAnswer[2].Id, lstAnswer[2].Text, cbAnswerJobThree.SelectedIndex);
            answer.EditAnswerOrientation(lstAnswer[3].Id, lstAnswer[3].Text, cbAnswerJobFour.SelectedIndex);
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            View.wAdminQuestion pg = new View.wAdminQuestion(message, questionSelected);
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

            foreach(Job j in vmStart.lstjobs)
            {
                cbAnswerJobOne.Items.Add(j.Name.ToString());
                cbAnswerJobTwo.Items.Add(j.Name.ToString());
                cbAnswerJobThree.Items.Add(j.Name.ToString());
                cbAnswerJobFour.Items.Add(j.Name.ToString());
            }
        }
    }
        
}
