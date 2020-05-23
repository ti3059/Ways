using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ways.Model
{
    public class Candidate
    {
		private string _surnameGame;            //Bdd
		private int _resultGame;                //Bdd
		private int _rankGame;                  //Bdd
		private List<string> _buddyListGame;    //-bdd
		private int _point;                     //-bdd

		private string _surnameOrientation;     //?Bdd
		private string _emailOrientation;       //-Bdd
		private string _resultOrientation;      //-Bdd

		private List<int> orientationPoints; //tableau parallèle aux métiers contenant à la même index le nombre de points du métier
		public Candidate()
		{

		}
		public string SurnameGame { get => _surnameGame; set => _surnameGame = value; }
		public int ResultGame { get => _resultGame; set => _resultGame = value; }
		public int RankGame { get => _rankGame; set => _rankGame = value; }
		public List<string> BuddyListGame { get => _buddyListGame; set => _buddyListGame = value; }
		public int Point { get => _point; set => _point = value; }
		public string SurnameOrientation { get => _surnameOrientation; set => _surnameOrientation = value; }
		public string EmailOrientation { get => _emailOrientation; set => _emailOrientation = value; }
		public string ResultOrientation { get => _resultOrientation; set => _resultOrientation = value; }
		public List<int> OrientationPoints { get => orientationPoints; set => orientationPoints = value; }

		public void UpOrientation(int jobIndex)
		{
			OrientationPoints[jobIndex] ++;
		}

		public void UpPoints()
		{
			Point ++;
		} 
	}
}
