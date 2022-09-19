using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Lexicon_Assignment.Models
{
    internal class Person
    {
        private readonly int Id;
        private string? FirstName;
        private string? LastName;

        public Person(int id, string firstName, string lastName)
        {
            this.Id = ++Id;
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                this.FirstName = firstName;
            } else throw new ArgumentNullException();
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                this.LastName = lastName;
            } else throw new ArgumentNullException();
        }
        public string fullName {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public int getID {
            get
            {
                return Id;
            }
        }
    }
}
