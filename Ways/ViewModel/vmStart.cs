using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ways.Model;

namespace Ways.ViewModel
{
    class vmStart
    {
        public static void getQuestionsGame()
        {
            Questions_Game game = new Questions_Game();
            List<Questions_Game> lstQustionsGames = game.SelectQuestionsGame();
        }

        public static void getJobs()
        {
            Job job = new Job();
            List<Job> lstJobs = job.SelectJobs();
        }

        public static void getSkills()
        {
            Skill skill = new Skill();
            List<Skill> lstSkills = skill.SelectSkills(getJobs());
        }
    }
}
