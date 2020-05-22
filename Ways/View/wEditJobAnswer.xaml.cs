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
    /// Logique d'interaction pour wEditJobAnswer.xaml
    /// </summary>
    public partial class wEditJobAnswer : Window
    {
        private Questions_Game questionSelected;
        private List<Model.Answer_Game> lstAnswer = new List<Model.Answer_Game>();

        public wEditJobAnswer(Questions_Game q, List<Model.Answer_Game> lst)
        {
            InitializeComponent();
            questionSelected = q;
            lstAnswer = lst;
        }

        public wEditJobAnswer()
        {
            InitializeComponent();
        }

        /*private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Answer_Game answer = new Answer_Game();
            answer.EditAnswerGame(lstAnswer[0].Id, lstAnswer[0].Text, );
            answer.EditAnswerGame(lAnswerOne.Text.ToString(), true);
            answer.EditAnswerGame(bAnswerTwo.Text.ToString(), true);
            answer.EditAnswerGame(bAnswerThree.Text.ToString(), true);
            answer.EditAnswerGame(bAnswerFour.Text.ToString(), true);
        }*/

    }
}
