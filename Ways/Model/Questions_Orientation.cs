using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ways.Model
{

    class Questions_Orientation
    {
        private int _id;
        private string _question;

        public Questions_Orientation(int id, string question)
        {
            Id = id;
            Question = question;
        }

        public int Id { get => _id; set => _id = value; }
        public string Question { get => _question; set => _question = value; }
    }
}
