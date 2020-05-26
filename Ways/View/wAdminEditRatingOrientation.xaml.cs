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
    public partial class wAdminEditRatingOrientation : Window
    {
        private Questions_Orientation questionSelected;
        private List<Answer_Orientation> lstAnswer = new List<Answer_Orientation>();
        private string currentTest;

        public wAdminEditRatingOrientation(Questions_Orientation question, string msg)
        {
            InitializeComponent();
            questionSelected = question;
            currentTest = msg;
            Answer_Orientation answerOrientation = new Answer_Orientation();
            lstAnswer = answerOrientation.SelectAnswerOrientationFromQuestionOrientationId(questionSelected.Id);
            setAnswers();
        }

        public wAdminEditRatingOrientation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Answer_Orientation newAnswerOrientation = new Answer_Orientation();
            newAnswerOrientation.EditJobAnswerOrientation(lstAnswer[0].Id, cbAnswerJobOne.SelectedIndex);
            newAnswerOrientation.EditJobAnswerOrientation(lstAnswer[1].Id, cbAnswerJobTwo.SelectedIndex);
            newAnswerOrientation.EditJobAnswerOrientation(lstAnswer[2].Id, cbAnswerJobThree.SelectedIndex);
            newAnswerOrientation.EditJobAnswerOrientation(lstAnswer[3].Id, cbAnswerJobFour.SelectedIndex);
            View.wAdminQuestionSelected pg = new View.wAdminQuestionSelected(currentTest, questionSelected);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            View.wAdminQuestionSelected pg = new View.wAdminQuestionSelected(currentTest, questionSelected);
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
