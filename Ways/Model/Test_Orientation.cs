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
    public class Test_Orientation
    {
        private Candidate candidate;
        private Questions_Orientation currentQuestion;
        private List<Questions_Orientation> questions;
        private Test_Orientation testOr;


        public Test_Orientation(Candidate c)
        {
            Questions_Orientation question_Orientation = new Questions_Orientation();
            Questions = question_Orientation.SelectQuestionsOrientation();
            currentQuestion = Questions[0];
            Candidate = c;
        }

        public Candidate Candidate { get => candidate; set => candidate = value; }
        public Questions_Orientation CurrentQuestion { get => currentQuestion; set => currentQuestion = value; }
        public List<Questions_Orientation> Questions { get => questions; set => questions = value; }
        public Test_Orientation TestOr { get => testOr; set => testOr = value; }

        public void Reply(int jobIndex)
        {
            Candidate.UpOrientation(jobIndex);
            Questions_Orientation nextQuestionOrientation = new Questions_Orientation();

            for (int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i] == CurrentQuestion)
                {
                    if(i < Questions.Count - 1)
                    {
                        nextQuestionOrientation = Questions[i + 1];
                    }
                    else
                    {
                        nextQuestionOrientation = null;
                    }
                }
            }

            currentQuestion = nextQuestionOrientation;
        }

    }
}
