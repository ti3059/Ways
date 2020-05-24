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

        public Test_Game(Candidate c)
        {
            Questions_Game question_Game = new Questions_Game();
            Questions = question_Game.SelectQuestionsGame();
            currentQuestion = Questions[0];
            Candidate = c;
        }

        public Candidate Candidate { get => candidate; set => candidate = value; }
        public Questions_Game CurrentQuestion { get => currentQuestion; set => currentQuestion = value; }
        public List<Questions_Game> Questions { get => questions; set => questions = value; }

        public void Reply(bool answerSelected)
        {
            Candidate.UpPoints();
            Questions_Game nextQuestionGame = new Questions_Game();

            for (int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i] == CurrentQuestion)
                {
                    if (i < Questions.Count - 1)
                    {
                        nextQuestionGame = Questions[i + 1];
                    }
                    else
                    {
                        nextQuestionGame = null;
                    }
                }
            }

            currentQuestion = nextQuestionGame;
        }

    }
}
