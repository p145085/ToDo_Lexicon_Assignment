using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_Lexicon_Assignment.Models;

namespace ToDo_Lexicon_Assignment.Data
{
    public class TodoSequencer
    {
        private static int todoId;

        public static int NextTodoId()
        {
            return TodoId++;
        }
        public static void Reset()
        {
            TodoId = 0;
        }
        public static int TodoId
        {
            get
            {
                return todoId;
            }
            set
            {
                todoId = value;
            }
        }
    }
}
