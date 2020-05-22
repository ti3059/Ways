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
        private Questions_Game questionSelected;
        private List<Answer_Game> lstAnswer = new List<Answer_Game>();

        public wEditRightAnswer(Questions_Game question, List<Answer_Game> list)
        {
            InitializeComponent();
            questionSelected = question;
            lstAnswer = list;
        }

        public wEditRightAnswer()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Answer_Game answer = new Answer_Game();
            answer.EditAnswerGame(lstAnswer[0].Id, lstAnswer[0].Text, (bool)chbAnswerOne.IsChecked);
            answer.EditAnswerGame(lstAnswer[1].Id, lstAnswer[1].Text, (bool)chbAnswerTwo.IsChecked);
            answer.EditAnswerGame(lstAnswer[2].Id, lstAnswer[2].Text, (bool)chbAnswerThree.IsChecked);
            answer.EditAnswerGame(lstAnswer[3].Id, lstAnswer[3].Text, (bool)chbAnswerFour.IsChecked);
        }
    }
}
