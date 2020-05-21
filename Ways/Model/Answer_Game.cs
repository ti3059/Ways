using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ways.Model
{
    public class Answer_Game
    {
        private int _id;
        private int _questionId;
        private string _text;
        private bool _right;

        public Answer_Game(int id, int questionId, string text, bool right)
        {
            Id = id;
            QuestionId = questionId;
            Text = text;
            Right = right;
        }

        public Answer_Game()
        {

        }

        public int Id { get => _id; set => _id = value; }
        public int QuestionId { get => _questionId; set => _questionId = value; }
        public string Text { get => _text; set => _text = value; }
        public bool Right { get => _right; set => _right = value; }

        public void AddAnswerGame(string answer, bool right)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "INSERT INTO reponses_jeu(reponse, vrai) VALUES (@answer, @right)";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@answer", answer);
            cmd.Parameters.AddWithValue("@right", right);
            cmd.ExecuteNonQuery();
            //long id = cmd.LastInsertedId;
            s.connection.Close();
        }

        public void DeleteAnswersGameFromQuestionId(int questionId)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "DELET FROM reponses_jeu WHERE question_id = @questionId)";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@questionId", questionId);
            cmd.ExecuteNonQuery();
            s.connection.Close();
        }

        public void EditAnswerGame(int id, string answer, bool right)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "UPDATE question_jeu SET question = @answer, vrai = @right WHERE id = @id)";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@answer", answer);
            cmd.Parameters.AddWithValue("@right", right);
            cmd.ExecuteNonQuery();
            s.connection.Close();
        }

        public List<Answer_Game> SelectAnswerGameFromQuestionGameId(int id)
        {
            MySqlDataReader reader = null;
            Server s = new Server();
            List<Answer_Game> _lstAnswerGame = new List<Answer_Game>();

            try
            {
                s.connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM reponses_jeu", s.connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Answer_Game _answer_Game = TransformToAnswer(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["question_id"]), Convert.ToString(reader["text"]), Convert.ToBoolean(reader["right"]));
                        _lstAnswerGame.Add(_answer_Game);                    
                    }
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (s.connection != null)
                    s.connection.Close();             
            }
            return _lstAnswerGame;
        }

        private Answer_Game TransformToAnswer(int id, int question_id, string text, bool right)
        {
            Answer_Game answerGame = new Answer_Game(id, question_id, text, right);
            return answerGame;
        }

    }
}
