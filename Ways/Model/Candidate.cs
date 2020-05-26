using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ways.Model
{
    public class Candidate
    {
		private string surname;
		private int id;

		private int score;                     //-bdd

		private Test_Orientation testOrientation;
		private Test_Game testGame;

		private List<string> lstInfoCandidate;
		private List<Candidate> lstCandidate = new List<Candidate>();

		private bool info = false;


		private List<int> orientationPoints = new List<int>(); //tableau parallèle aux métiers contenant à la même index le nombre de points du métier
		public Candidate()
		{

		}

		public Candidate(int newScore, string surname)
        {
			Score = newScore;
			Surname = surname;
        }

		public Candidate(List<Job> lstJobs)
        {
			Test_Orientation = new Test_Orientation(this);
			Test_Game = new Test_Game(this);

			for(int i = 0; i < lstJobs.Count; i++)
            {
				OrientationPoints.Add(0);
            }
        }

		public List<int> OrientationPoints { get => orientationPoints; set => orientationPoints = value; }
        public string Surname { get => surname; set => surname = value; }
        public List<string> LstInfoCandidate { get => lstInfoCandidate; set => lstInfoCandidate = value; }
		public Test_Orientation Test_Orientation { get => testOrientation; set => testOrientation = value; }
        public Test_Game Test_Game { get => testGame; set => testGame = value; }
        public int Id { get => id; set => id = value; }
		public List<Candidate> LstCandidate { get => lstCandidate; set => lstCandidate = value; }
        public bool Info { get => info; set => info = value; }
        public int Score { get => score; set => score = value; }

        public void UpOrientation(int jobIndex)
		{
			OrientationPoints[jobIndex]++;
		}

		public void UpPoints()
		{
			Score ++;
			UpdatePoint();
		} 

		public void SaveInfoInBase()
        {
			Server s = new Server();
			s.connection.Open();
			string requestCandidate = "INSERT INTO candidate(score, surname) VALUES (@score, @surname)";
			MySqlCommand cmd1 = new MySqlCommand(requestCandidate, s.connection);
			cmd1.Parameters.AddWithValue("@score", Score);
			cmd1.Parameters.AddWithValue("@surname", Surname);
			cmd1.ExecuteNonQuery();
			int idCandidate = Convert.ToInt32(cmd1.LastInsertedId);
			s.connection.Close();

			s.connection.Open();
			string requestInfo = "INSERT INTO info(info_1, info_2, info_3, info_4, info_5, info_6, info_7, info_8, " +
				"info_9, info_10) VALUES (@info_1, @info_2, @info_3, @info_4, @info_5, @info_6, @info_7, @info_8, " +
				"@info_9, @info_10)";
			MySqlCommand cmd2 = new MySqlCommand(requestInfo, s.connection);
			cmd2.Parameters.AddWithValue("@info_1", LstInfoCandidate[0]);
			cmd2.Parameters.AddWithValue("@info_2", LstInfoCandidate[1]);
			cmd2.Parameters.AddWithValue("@info_3", LstInfoCandidate[2]);
			cmd2.Parameters.AddWithValue("@info_4", LstInfoCandidate[3]);
			cmd2.Parameters.AddWithValue("@info_5", LstInfoCandidate[4]);
			cmd2.Parameters.AddWithValue("@info_6", LstInfoCandidate[5]);
			cmd2.Parameters.AddWithValue("@info_7", LstInfoCandidate[6]);
			cmd2.Parameters.AddWithValue("@info_8", LstInfoCandidate[7]);
			cmd2.Parameters.AddWithValue("@info_9", LstInfoCandidate[8]);
			cmd2.Parameters.AddWithValue("@info_10", LstInfoCandidate[9]);
			cmd2.ExecuteNonQuery();
			int idInfo = Convert.ToInt32(cmd2.LastInsertedId);
			s.connection.Close();

			s.connection.Open();
			string requestCandidateInfo = "INSERT INTO candidat_infos(id_candidat, id_info) VALUES (@id_candidat, @id_info)";
			MySqlCommand cmd3 = new MySqlCommand(requestCandidateInfo, s.connection);
			cmd3.Parameters.AddWithValue("@id_candidat", idCandidate);
			cmd3.Parameters.AddWithValue("@id_info", idInfo);
			cmd3.ExecuteNonQuery();
			long id = cmd3.LastInsertedId;
			s.connection.Close();

			Id = idCandidate;
			Info = true;
		}

		public List<Candidate> SelectAllCandidates()
		{
			MySqlDataReader reader = null;
			Server s = new Server();
			List<Candidate> _lstCandidates = new List<Candidate>();

			try
			{
				s.connection.Open();
				MySqlCommand command = new MySqlCommand("SELECT * FROM candidate", s.connection);
				using (reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						Candidate _candidate = TransformToCandidate(Convert.ToInt32(reader["score"]), Convert.ToString(reader["surname"]));
						_lstCandidates.Add(_candidate);
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
			return _lstCandidates;
		}

		private Candidate TransformToCandidate(int score, string surname)
		{
			Candidate candidate = new Candidate(score, surname);
			return candidate;
		}

		public void UpdatePoint()
        {
			Server s = new Server();
			s.connection.Open();
			string request = "UPDATE candidate SET score = @score WHERE id = @id";
			MySqlCommand cmd = new MySqlCommand(request, s.connection);
			cmd.Parameters.AddWithValue("@score", Score);
			cmd.Parameters.AddWithValue("@id", Id);
			cmd.ExecuteNonQuery();
			s.connection.Close();
		}

	}
}
