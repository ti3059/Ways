using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ways.Model
{

    public class Questions_Orientation
    {
        private int id;
        private string question;

        public Questions_Orientation(int id, string question)
        {
            Id = id;
            Question = question;
        }
        public Questions_Orientation()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Question { get => question; set => question = value; }

        public long AddQuestionOrientation(string question)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "INSERT INTO questions_orientation(question) VALUES (@question)";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@question", question);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            s.connection.Close();
            return id;
        }

        public void DeleteQuestionOrientation(int id)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "DELETE FROM questions_orientation WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            s.connection.Close();
        }

        public void EditQuestionOrientation(int id, string question)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "UPDATE questions_orientation SET question = @question WHERE id = @id)";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@question", question);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            s.connection.Close();
        }

        public List<Questions_Orientation> SelectQuestionsOrientation()
        {
            MySqlDataReader reader = null;
            Server s = new Server();
            List<Questions_Orientation> _lstQuestionsOrientation = new List<Questions_Orientation>();

            try
            {
                s.connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM questions_orientation", s.connection);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Questions_Orientation _question_Orientation = TransformToQuestion(Convert.ToInt32(reader["id"]), Convert.ToString(reader["question"]));
                        _lstQuestionsOrientation.Add(_question_Orientation);
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
            return _lstQuestionsOrientation;
        }

        private Questions_Orientation TransformToQuestion(int id, string question)
        {
            Questions_Orientation questionOrientation = new Questions_Orientation(id, question);
            return questionOrientation;
        }

    }
}
