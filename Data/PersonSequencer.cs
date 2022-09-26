using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Lexicon_Assignment.Data
{
    public class PersonSequencer
    {
        private static int personId;

        public static int NextPersonId()
        {
            return personId++;
        }
        public static void Reset()
        {
            personId = 0;
        }

        public int PersonId
        {
            get
            {
                return personId;
            }
            set
            {
                personId = value;
            }
        }
    }
}
