using MySql.Data.MySqlClient;
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
    /// Logique d'interaction pour wEditQuestion.xaml
    /// </summary>
    public partial class wEditQuestion : Window
    {
        private string msg;
        Questions_Game qGame;
        Questions_Orientation qOr;
        Server s = new Server();

        public wEditQuestion(string choice)
        {
            InitializeComponent();
            msg = choice;
        }

        public wEditQuestion(string choice, Questions_Game q)
        {
            InitializeComponent();
            qGame = q;
        }

        public wEditQuestion(string choice, Questions_Orientation q)
        {
            InitializeComponent();
            qOr = q;
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            View.wAdmin pg = new View.wAdmin(msg);
            pg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            pg.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(msg == "GAME")
            {
                s.connection.Open();

                //Ajout de la question
                string cmdQuestionText = "INSERT INTO question_jeu(question) VALUES (@question)";
                MySqlCommand cmd = new MySqlCommand(cmdQuestionText, s.connection);
                cmd.Parameters.AddWithValue("@question", tbQuestion.Text);
                cmd.ExecuteNonQuery();

                long id = cmd.LastInsertedId;

                //Ajout des réponses
                string cmtAns = "INSERT INTO reponses_jeu(question_id, reponse, vrai) VALUES (@question_id, @reponse, @vrai)";

                MySqlCommand cmd1 = new MySqlCommand(cmtAns, s.connection);
                cmd1.Parameters.AddWithValue("@question_id", id);
                cmd1.Parameters.AddWithValue("@reponse", tbAnswerOne.Text);
                cmd1.Parameters.AddWithValue("@vrai", true);


                MySqlCommand cmd2 = new MySqlCommand(cmtAns, s.connection);
                cmd2.Parameters.AddWithValue("@question_id", id);
                cmd2.Parameters.AddWithValue("@reponse", tbAnswerTwo.Text);
                cmd2.Parameters.AddWithValue("@vrai", false);


                MySqlCommand cmd3 = new MySqlCommand(cmtAns, s.connection);
                cmd3.Parameters.AddWithValue("@question_id", id);
                cmd3.Parameters.AddWithValue("@reponse", tbAnswerThree.Text);
                cmd3.Parameters.AddWithValue("@vrai", false);


                MySqlCommand cmd4 = new MySqlCommand(cmtAns, s.connection);
                cmd4.Parameters.AddWithValue("@question_id", id);
                cmd4.Parameters.AddWithValue("@reponse", tbAnswerFour.Text);
                cmd4.Parameters.AddWithValue("@vrai", false);


                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();

                s.connection.Close();


            }
            else
            {
                //
            }
        }
    }
}
