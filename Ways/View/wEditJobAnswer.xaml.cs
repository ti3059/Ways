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
            answer.EditJobAnswerOrientation(lstAnswer[0].Id, cbAnswerJobOne.SelectedIndex);
            answer.EditJobAnswerOrientation(lstAnswer[1].Id, cbAnswerJobTwo.SelectedIndex);
            answer.EditJobAnswerOrientation(lstAnswer[2].Id, cbAnswerJobThree.SelectedIndex);
            answer.EditJobAnswerOrientation(lstAnswer[3].Id, cbAnswerJobFour.SelectedIndex);
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
                cbAnswerJobOne.SelectedIndex = lstAnswer[0].JobIndex;
                cbAnswerJobTwo.Items.Add(j.Name.ToString());
                cbAnswerJobTwo.SelectedIndex = lstAnswer[1].JobIndex;
                cbAnswerJobThree.Items.Add(j.Name.ToString());
                cbAnswerJobThree.SelectedIndex = lstAnswer[2].JobIndex;
                cbAnswerJobFour.Items.Add(j.Name.ToString());
                cbAnswerJobFour.SelectedIndex = lstAnswer[3].JobIndex;
            }
        }
    }
        
}
