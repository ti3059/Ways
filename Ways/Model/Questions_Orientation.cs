using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ways.Model
{

    class Questions_Orientation
    {
        private int _id;
        private string _question;

        public Questions_Orientation(int id, string question)
        {
            Id = id;
            Question = question;
        }
        public Questions_Orientation()
        {

        }

        private void AddQuestionOrientation(string question)
        {
            Server s = new Server();
            try
            {
                s.connection.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO questions_orientation(question) VALUES(@person)", s.connection);
                command.Parameters.AddWithValue("@person", "Myname");
                command.Parameters.AddWithValue("@address", "Myaddress");
                command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                s.connection.Close();
            }
        }

        private void DeleteQuestionOrientation(int id)
        {

        }

        private void EditQuestionOrientation(int id, string question)
        {

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


        public int Id { get => _id; set => _id = value; }
        public string Question { get => _question; set => _question = value; }
    }
}
