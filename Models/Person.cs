using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Lexicon_Assignment.Models
{
    public class Person
    {
        private readonly int id;
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.id = id;
        }

        public string? FirstName 
        { 
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Firstname cannot be null.");
                }
                else
                {
                    this.firstName = value;
                }
            }
        }
        public string? LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("lastName cannot be null.");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        public string fullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public int PersonId {
            get
            {
                return id;
            }
        }
    }
}
