﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ways.Model;

namespace Ways.ViewModel
{
    class vmStart
    {
        public static List<Questions_Game> lstQustionsGames = new List<Questions_Game>();
        public static List<Questions_Orientation> lstQuestionsOrientation = new List<Questions_Orientation>();
        public static void getQuestionsGame()
        {
            Questions_Game game = new Questions_Game();
            lstQustionsGames = game.SelectQuestionsGame();
        }

        public static void getQuestionsOrientation()
        {
            Questions_Orientation or = new Questions_Orientation();
            lstQuestionsOrientation = or.SelectQuestionsOrientation();
        }

        public static void getJobs()
        {
            Job job = new Job();
            List<Job> lstJobs = job.SelectJobs();
        }

        public static void getSkills()
        {
            Job job = new Job();
            Skill skill = new Skill();
            List<Skill> lstSkills = skill.SelectSkills(job.SelectJobs());
        }
    }
}
