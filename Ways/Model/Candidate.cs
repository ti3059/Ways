using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ways.Model
{
    public class Candidate
    {
		private string _surname;

		private int _resultGame;                //Bdd
		private int _rankGame;                  //Bdd
		private List<string> _buddyListGame;    //-bdd
		private int _point;                     //-bdd

		private string _emailOrientation;       //-Bdd
		private string _resultOrientation;      //-Bdd

		private Test_Orientation _test_Orientation;
		private Test_Game _test_Game;

		private List<string> _lstInfoCandidate;

		private List<int> orientationPoints = new List<int>(); //tableau parallèle aux métiers contenant à la même index le nombre de points du métier
		public Candidate()
		{

		}

		public Candidate(List<Job> lstJobs)
        {
			Test_Orientation = new Test_Orientation(this);
			Test_Game = new Test_Game();

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

        public void UpOrientation(int jobIndex)
		{
			OrientationPoints[jobIndex]++;
		}

		public void UpPoints()
		{
			Point ++;		
		} 
	}
}
