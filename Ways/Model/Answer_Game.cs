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
        private int id;
        private int questionId;
        private string text;
        private bool right;

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

        public int Id { get => id; set => id = value; }
        public int QuestionId { get => questionId; set => questionId = value; }
        public string Text { get => text; set => text = value; }
        public bool Right { get => right; set => right = value; }

        public void AddAnswerGame(string answer, int id, bool right)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "INSERT INTO reponses_jeu(reponse, question_id, vrai) VALUES (@answer, @id, @right)";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@answer", answer);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@right", right);
            cmd.ExecuteNonQuery();
            //long id = cmd.LastInsertedId;
            s.connection.Close();
        }

        public void DeleteAnswersGameFromQuestionId(int questionId)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "DELETE FROM reponses_jeu WHERE question_id = @questionId";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@questionId", questionId);
            cmd.ExecuteNonQuery();
            s.connection.Close();
        }

        public void EditRightAnswerGame(int id, bool right)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "UPDATE reponses_jeu SET vrai = @right WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@right", right);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            s.connection.Close();
        }
        public void EditTextAnswerGame(int id, string answer)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "UPDATE reponses_jeu SET reponse = @reponse WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@reponse", answer);
            cmd.Parameters.AddWithValue("@id", id);
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
                MySqlCommand command = new MySqlCommand("SELECT * FROM reponses_jeu where question_id = @question_id", s.connection);
                command.Parameters.AddWithValue("@question_id", id);
                using (reader = command.ExecuteReader())    
                {
                    while (reader.Read())
                    {
                        Answer_Game _answer_Game = TransformToAnswer(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["question_id"]), Convert.ToString(reader["reponse"]), Convert.ToBoolean(reader["vrai"]));
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
