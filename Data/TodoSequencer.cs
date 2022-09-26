using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Lexicon_Assignment.Data
{
    public class TodoSequencer
    {
        private static int TodoId;

        public static int NextTodoId()
        {
            return TodoId++;
        }
        public static void Reset()
        {
            TodoId = 0;
        }
    }
}
