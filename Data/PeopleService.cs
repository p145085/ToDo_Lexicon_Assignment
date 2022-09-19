﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_Lexicon_Assignment.Models;

namespace ToDo_Lexicon_Assignment.Data
{
    internal class PeopleService
    {
        private static Person[] people = new Person[0];
        public int Size() { return people.Length; }
        public Person[] FindAll() { return people; }
        public Person FindById(int id) { return people[id]; }

        public Person AddNewPerson(string firstName, string lastName)
        {
            Person newPerson = new Person(PersonSequencer.NextPersonId(), firstName, lastName);
            people.Append(newPerson);
            return newPerson;
        }
        public void Clear()
        {
            people = new Person[0];
        }
    }
}