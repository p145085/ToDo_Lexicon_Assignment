using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_Lexicon_Assignment.Models;

namespace ToDo_Lexicon_Assignment.Data
{
    internal class TodoService
    {
        private static Todo[] todos = new Todo[0];
        public int Size() { return todos.Length; }
        public Todo[] FindAll() { return todos; }
        public Todo FindById(int id) { return todos[id]; }

        public Todo AddNewTodo(string description)
        {
            Todo newTodo = new Todo(TodoSequencer.NextTodoId(), description);
            todos.Append(newTodo);
            return newTodo;
        }
        public void Clear()
        {
            todos = new Todo[0];
        }

        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] foo = new Todo[0];
            foreach (Todo todo in todos)
            {
                if (todo.myDone == doneStatus)
                {
                    foo.Append(todo);
                }
            }
            return foo;
        }

        public Todo[] FindByAssignee(int personId)
        {
            Todo[] foo = new Todo[0];
            foreach (Todo todo in todos)
            {
                if (todo.myID == personId)
                {
                    foo.Append(todo);
                }
            }
            return foo;
        }

        public Todo[] FindByAssignee(Person assignee)
        {
            Todo[] foo = new Todo[0];
            foreach (Todo todo in todos)
            {
                if (todo.myAssignee == assignee)
                {
                    foo.Append(todo);
                }
            }
            return foo;
        }

        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] foo = new Todo[0];
            foreach (Todo todo in todos)
            {
                if (todo.myAssignee == null)
                {
                    foo.Append(todo);
                }
            }
            return foo;
        }

        public void RemoveTodo(int id)
        {
            Todo found = FindById(id);

            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i] == found)
                {
                    for (int offset = i + 1; offset < todos.Length; offset++, i++)
                    {
                        todos[i] = todos[offset];
                    }
                    Array.Resize(ref todos, todos.Length - 1);
                    break;
                }
            }
        }
    }
}
