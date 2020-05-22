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
    /// Logique d'interaction pour wEditJobAnswer .xaml
    /// </summary>
    public partial class wEditJobAnswer : Window
    {
        private Questions_Orientation questionSelected;
        private List<Answer_Orientation> listAnswer = new List<Answer_Orientation>();
        public wEditJobAnswer(Questions_Orientation question, List<Answer_Orientation> list)
        {
            InitializeComponent();
            questionSelected = question;
            listAnswer = list;

        }

        public wEditJobAnswer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Answer_Orientation answer = new Answer_Orientation();
            answer.EditAnswerOrientation(listAnswer[0].Id, listAnswer[0].Text, cbAnswerJobOne.SelectedIndex);
            answer.EditAnswerOrientation(listAnswer[1].Id, listAnswer[1].Text, cbAnswerJobTwo.SelectedIndex);
            answer.EditAnswerOrientation(listAnswer[2].Id, listAnswer[2].Text, cbAnswerJobThree.SelectedIndex);
            answer.EditAnswerOrientation(listAnswer[3].Id, listAnswer[3].Text, cbAnswerJobFour.SelectedIndex);
        }
    }
        
}
