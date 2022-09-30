using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Lexicon_Assignment.Models
{
    public class Todo
    {
        private readonly int id;
        private string? description;
        private bool done;
        private Person? assignee;

        public Todo(int id, string? description)
        {
            TodoId = id;
            Description = description;
        }
        public int TodoId { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public Person Assignee { get; set; }
    }
}
