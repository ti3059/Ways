using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ways.Model
{
    public class Test_Game
    {
        private Candidate candidate;
        private Questions_Game currentQuestion;
        private List<Questions_Game> questions;

        public Test_Game(Candidate candidate)
        {
            Candidate = candidate;
            Questions_Game question_Game = new Questions_Game();
            Questions = question_Game.SelectQuestionsGame();
            currentQuestion = Questions[0];
        }

        public Candidate Candidate { get => candidate; set => candidate = value; }
        public Questions_Game CurrentQuestion { get => currentQuestion; set => currentQuestion = value; }
        public List<Questions_Game> Questions { get => questions; set => questions = value; }

        public void Reply(bool answerSelected)
        {
            if(answerSelected)
            {
                Candidate.UpPoints();
            }
            if(Questions[Questions.Count] != CurrentQuestion)
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
