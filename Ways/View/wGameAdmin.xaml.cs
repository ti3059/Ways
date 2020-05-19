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
    /// Logique d'interaction pour wGameAdmin.xaml
    /// </summary>
    public partial class wGameAdmin : Window
    {
        public wGameAdmin()
        {
            InitializeComponent();
            addQuestionToListView();
        }

        public void addQuestionToListView()
        {
            foreach(Questions_Game q in vmStart.lstQustionsGames)
            {
                lvGameAdmin.Items.Add(q);
            }
        }
    }
}
