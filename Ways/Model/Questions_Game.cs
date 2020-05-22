using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ways.Model
{
    public class Questions_Game
    {
        private int _id;
        private string _question;

        public Questions_Game(int id, string question)
        {
            Id = id;
            Question = question;
        }

        public Questions_Game()
        {

        }

        public long AddQuestionGame(string question)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "INSERT INTO question_jeu(question) VALUES (@question)";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@question", question);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            s.connection.Close();
            return id;
        }

        public void DeleteQuestionGame(int id)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "DELETE FROM question_jeu WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            s.connection.Close();
        }

        public void EditQuestionGame(int id, string question)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "UPDATE question_jeu SET question = @question WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@question", question);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            s.connection.Close();
        }
            
        public List<Questions_Game> SelectQuestionsGame()
        {
            MySqlDataReader reader = null;
            Server s = new Server();
            List<Questions_Game> _lstQuestionsGame = new List<Questions_Game>();

            try
            {
                s.connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM question_jeu", s.connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Questions_Game _question_Game = TransformToQuestion(Convert.ToInt32(reader["id"]), Convert.ToString(reader["question"]));
                        _lstQuestionsGame.Add(_question_Game);                    
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
            return _lstQuestionsGame;
        }

        private Questions_Game TransformToQuestion(int id, string question)
        {
            Questions_Game questionGame = new Questions_Game(id, question);
            return questionGame;
        }

        public int Id { get => _id; set => _id = value; }
        public string Question { get => _question; set => _question = value; }
    }
}
