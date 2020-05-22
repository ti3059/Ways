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
    /// Logique d'interaction pour wEditRightAnswer.xaml
    /// </summary>
    public partial class wEditRightAnswer : Window
    {
        private Questions_Orientation questionSelected;
        private List<Model.Answer_Orientation> lstAnswer = new List<Model.Answer_Orientation>();
        public wEditRightAnswer(Model.Questions_Orientation q, List<Model.Answer_Orientation> list)
        {
            InitializeComponent();
            lstAnswer = list;
            questionSelected = q;

        }

        public wEditRightAnswer()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            /*Answer_Orientation answer = new Answer_Orientation();
            answer.EditAnswerOrientation(lstAnswer[0].Id, lstAnswer[0].Text, );
            answer.EditAnswerOrientation(lAnswerOne.Text.ToString(), true);
            answer.EditAnswerOrientation(bAnswerTwo.Text.ToString(), true);
            answer.EditAnswerOrientation(bAnswerThree.Text.ToString(), true);
            answer.EditAnswerOrientation(bAnswerFour.Text.ToString(), true);*/
        }
    }
        
}
