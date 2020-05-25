using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ways.Model;

namespace Ways.ViewModel
{
    class vmStart
    {
        public static List<Questions_Game> lstQustionsGames = new List<Questions_Game>();
        public static List<Questions_Orientation> lstQuestionsOrientation = new List<Questions_Orientation>();
        public static List<Job> lstjobs = new List<Job>();
        public static void getQuestionsGame()
        {
            Questions_Game newGame = new Questions_Game();
            lstQustionsGames.Clear();
            lstQustionsGames = newGame.SelectQuestionsGame();
        }

        public static void getQuestionsOrientation()
        {
            Questions_Orientation newGameOrientation = new Questions_Orientation();
            lstQuestionsOrientation.Clear();
            lstQuestionsOrientation = newGameOrientation.SelectQuestionsOrientation();
        }

        public static void getJobs()
        {
            Job job = new Job();
            lstjobs = job.SelectJobs();
        }
    }
}
