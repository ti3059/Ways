﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ways.Model
{
    public class Answer_Orientation
    {
        private int id;
        private int questionId;
        private string text;
        private int jobIndex;

        public Answer_Orientation(int id, int questionId, string text, int jobIndex)
        {
            Id = id;
            QuestionId = questionId;
            Text = text;
            JobIndex = jobIndex;
        }

        public Answer_Orientation()
        {

        }

        public int Id { get => id; set => id = value; }
        public int QuestionId { get => questionId; set => questionId = value; }
        public string Text { get => text; set => text = value; }
        public int JobIndex { get => jobIndex; set => jobIndex = value; }

        public void AddAnswerOrientation(string answer, int questionId, int jobIndex)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "INSERT INTO reponses_orientation(reponse, question_id, job_index) VALUES (@answer, @questionId, @jobIndex)";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@answer", answer);
            cmd.Parameters.AddWithValue("@questionId", questionId);
            cmd.Parameters.AddWithValue("@jobIndex", jobIndex);
            cmd.ExecuteNonQuery();
            //long id = cmd.LastInsertedId;
            s.connection.Close();
        }

        public void DeleteAnswersOrientationFromQuestionId(int questionId)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "DELETE FROM reponses_orientation WHERE question_id = @questionId";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@questionId", questionId);
            cmd.ExecuteNonQuery();
            s.connection.Close();
        }

        public void EditTextAnswerOrientation(int id, string answer)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "UPDATE reponses_orientation SET reponse = @answer WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@answer", answer);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            s.connection.Close();
        }
        public void EditJobAnswerOrientation(int id, int jobIndex)
        {
            Server s = new Server();
            s.connection.Open();
            string request = "UPDATE reponses_orientation SET job_index = @jobIndex WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(request, s.connection);
            cmd.Parameters.AddWithValue("@jobIndex", jobIndex);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            s.connection.Close();
        }

        public List<Answer_Orientation> SelectAnswerOrientationFromQuestionOrientationId(int id)
        {
            MySqlDataReader reader = null;
            Server s = new Server();
            List<Answer_Orientation> _lstAnswerOrientation = new List<Answer_Orientation>();

            try
            {
                s.connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM reponses_orientation where question_id = @question_id", s.connection);
                command.Parameters.AddWithValue("@question_id", id);
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Answer_Orientation _answer_Orientation= TransformToAnswer(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["question_id"]), Convert.ToString(reader["reponse"]), Convert.ToInt32(reader["job_index"]));
                        _lstAnswerOrientation.Add(_answer_Orientation);                    
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
            return _lstAnswerOrientation;
        }

        private Answer_Orientation TransformToAnswer(int id, int question_id, string text, int jobIndex)
        {
            Answer_Orientation answerOrientation = new Answer_Orientation(id, question_id, text, jobIndex);
            return answerOrientation;
        }

    }
}
