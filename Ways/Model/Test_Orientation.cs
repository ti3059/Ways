﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ways.Model
{
    public class Test_Orientation
    {
        private Candidate candidate;
        private Questions_Orientation currentQuestion;
        private List<Questions_Orientation> questions;

        public Test_Orientation(Candidate candidate)
        {
            Candidate = candidate;
            Questions_Orientation question_Orientation = new Questions_Orientation();
            Questions = question_Orientation.SelectQuestionsOrientation();
            currentQuestion = Questions[0];
        }

        public Candidate Candidate { get => candidate; set => candidate = value; }
        public Questions_Orientation CurrentQuestion { get => currentQuestion; set => currentQuestion = value; }
        public List<Questions_Orientation> Questions { get => questions; set => questions = value; }

        public void Reply(int jobIndex)
        {
            Candidate.UpOrientation(jobIndex);
            if (Questions[Questions.Count] != CurrentQuestion)
            {
                for (int i = 0; i <= Questions.Count; i++)
                {
                    if (Questions[i] == CurrentQuestion)
                    {
                        CurrentQuestion = Questions[i + 1];
                    }
                }
                //RECHARGEMENT DE LA PAGE AVEC LA NOUVELLE QUESTION
            }
            else
            {
                //CHARGEMENT DU MENU ET FIN DU TEST
            }
        }

    }
}
