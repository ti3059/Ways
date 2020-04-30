using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ways.Model
{
    class Job
    {
        public Dictionary<string, int> Dict_Jobs_Orientation = new Dictionary<string, int>();
        
        public Job()
        {

        }

        public void AddJobToDict(Dictionary<string, int> dict)
        {
            Dict_Jobs_Orientation.Add("Développeur", 0);
            Dict_Jobs_Orientation["Développeur"]++;
        }

    }
}
