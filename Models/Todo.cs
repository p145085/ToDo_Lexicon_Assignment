using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Lexicon_Assignment.Models
{
    public class Todo
    {
        private readonly int Id;
        private string? Description;
        private bool Done;
        private Person? Assignee;

        public Todo(int id, string? description)
        {
            Id = id;
            Description = description;
        }
        public int myID { get; set; }
        public string myDescription { get; set; }
        public bool myDone { get; set; }
        public Person myAssignee { get; set; }
    }
}
