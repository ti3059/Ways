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
		private string _surname;
		private int _id;

		private int _resultGame;                //Bdd
		private int _rankGame;                  //Bdd
		private List<string> _buddyListGame;    //-bdd
		private int _point;                     //-bdd

		private string _emailOrientation;       //-Bdd
		private string _resultOrientation;      //-Bdd

		private Test_Orientation _test_Orientation;
		private Test_Game _test_Game;

		private List<string> _lstInfoCandidate;
		private List<Candidate> lstCandidate = new List<Candidate>();

		private bool contact = false;


		private List<int> orientationPoints = new List<int>(); //tableau parallèle aux métiers contenant à la même index le nombre de points du métier
		public Candidate()
		{

		}

		public Candidate(int score, string surname)
        {
			Point = score;
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

		public int ResultGame { get => _resultGame; set => _resultGame = value; }
		public int RankGame { get => _rankGame; set => _rankGame = value; }
		public List<string> BuddyListGame { get => _buddyListGame; set => _buddyListGame = value; }
		public int Point { get => _point; set => _point = value; }
		public string EmailOrientation { get => _emailOrientation; set => _emailOrientation = value; }
		public string ResultOrientation { get => _resultOrientation; set => _resultOrientation = value; }
		public List<int> OrientationPoints { get => orientationPoints; set => orientationPoints = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public List<string> LstInfoCandidate { get => _lstInfoCandidate; set => _lstInfoCandidate = value; }
		public Test_Orientation Test_Orientation { get => _test_Orientation; set => _test_Orientation = value; }
        public Test_Game Test_Game { get => _test_Game; set => _test_Game = value; }
        public int Id { get => _id; set => _id = value; }
		public List<Candidate> LstCandidate { get => lstCandidate; set => lstCandidate = value; }
		public bool Contact { get => contact; set => contact = value; }

		public void UpOrientation(int jobIndex)
		{
			OrientationPoints[jobIndex]++;
		}

		public void UpPoints()
		{
			Point ++;		
		} 

		public void SaveInfoInBase()
        {
			Server s = new Server();
			s.connection.Open();
			string requestCandidate = "INSERT INTO candidate(score, surname) VALUES (@score, @surname)";
			MySqlCommand cmd1 = new MySqlCommand(requestCandidate, s.connection);
			cmd1.Parameters.AddWithValue("@score", Point);
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

		public void SetContacts(List<string> contacts)
		{
			Server s = new Server();
			s.connection.Open();
			foreach (string contact in contacts)
			{
				string requestContact = "INSERT INTO contact(mail) VALUES (@mail)";
				MySqlCommand cmd1 = new MySqlCommand(requestContact, s.connection);
				cmd1.Parameters.AddWithValue("@mail", contact);
				cmd1.ExecuteNonQuery();
				int id = (int)cmd1.LastInsertedId;

				string requestCandidateContact = "INSERT INTO candidate_contact(id_candidate, id_contact) VALUES (@id_candidate, @id_contact)";
				MySqlCommand cmd2 = new MySqlCommand(requestCandidateContact, s.connection);
				cmd2.Parameters.AddWithValue("@id_candidate", Id);
				cmd2.Parameters.AddWithValue("@id_contact", id);
				cmd2.ExecuteNonQuery();

				UpPoints();
			}
			s.connection.Close();
			Contact = true;
		}
	}
}
