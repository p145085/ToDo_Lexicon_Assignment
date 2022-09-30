using System;
using ToDo_Lexicon_Assignment.Data;
using ToDo_Lexicon_Assignment.Models;

namespace TestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void FirstNameBadValueTest(string badFirstName)
        {
            //Arrange
            Person testPerson = new Person("Åsa", "Jonsson", PersonSequencer.NextPersonId());
            //Act
            ArgumentException exception = Assert.Throws<ArgumentException>(() => testPerson.FirstName = badFirstName);
            //Assert
            Assert.Contains("Firstname", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void LastNameBadValueTest(string badLastName)
        {
            //Arrange
            Person testPerson = new Person("Sam", "Jonsson", PersonSequencer.NextPersonId());
            //Act
            var exception = Assert.Throws<ArgumentException>(() => testPerson.LastName = badLastName);
            //Assert
            Assert.Contains("Lastname", exception.Message);
        }

        [Fact]
        public void PersonClassTest()
        {
            // Arrange
            string firstName1 = "Sally";
            string lastName1 = "Corey";
            string firstName2 = "Mona";
            string lastName2 = "Carlesson";

            // Act
            Person testPerson1 = new Person(firstName1, lastName1, PersonSequencer.NextPersonId());
            Person testPerson2 = new Person(firstName2, lastName2, PersonSequencer.NextPersonId());

            // Assert        
            Assert.Equal(firstName1, testPerson1.FirstName);
            Assert.Equal(lastName1, testPerson1.LastName);
            Assert.Equal(firstName2, testPerson2.FirstName);
            Assert.Equal(lastName2, testPerson2.LastName);
        }

        [Fact]
        public void TodoClassTest()
        {
            //Arrange
            string description1 = "Finish assignment";
            string description2 = "Go for walk";

            //Act
            Todo testTodo1 = new Todo(TodoSequencer.NextTodoId(), description1);
            Todo testTodo2 = new Todo(TodoSequencer.NextTodoId(), description2);

            //Assert

            Assert.Equal(description1, testTodo1.Description);
            Assert.Equal(description2, testTodo2.Description);
        }

        [Fact]
        public void ResetPersonIdTest()
        {
            //Arrange
            PersonSequencer.Reset();
            int expected = 0;
            int actual;
            actual = PersonSequencer.PersonId;

            //Act
            PersonSequencer.PersonId = 5;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NextPersonIdTest()
        {
            //Arrange
            int expectedId1 = 1;
            int expectedId2 = 2;
            int id1;
            int id2;

            //Act
            id1 = PersonSequencer.NextPersonId();
            id2 = PersonSequencer.NextPersonId();

            //Assert
            Assert.Equal(expectedId1, id1);
            Assert.Equal(expectedId2, id2);
        }

        [Fact]
        public void ResetTodoIdTest()
        {
            //Arrange
            int expected = 0;
            TodoSequencer.TodoId = 4;

            //Act
            TodoSequencer.Reset();

            //Assert
            Assert.Equal(expected, TodoSequencer.TodoId);
        }

        [Fact]

        public void NextTodoIdTest()
        {
            //Arrange
            int expectedId1 = 1;
            int expectedId2 = 2;
            int id1;
            int id2;

            //Act
            id1 = TodoSequencer.NextTodoId();
            id2 = TodoSequencer.NextTodoId();

            //Assert
            Assert.Equal(expectedId1, id1);
            Assert.Equal(expectedId2, id2);
        }

        [Fact]

        public void CreateNewPersonTest()
        {
            PeopleService testingPeople = new PeopleService();
            testingPeople.Clear();
            string firstName1 = "Johanna";
            string lastName1 = "Ljungberg";
            string firstName2 = "Mona-Lisa";
            string lastName2 = "Harddrive";

            //Act
            Person testPerson1 = testingPeople.AddNewPerson(firstName1, lastName1);
            Person testPerson2 = testingPeople.AddNewPerson(firstName2, lastName2);

            //Assert
            Assert.Equal(firstName1, testPerson1.FirstName);
            Assert.Equal(lastName1, testPerson1.LastName);

            Assert.Equal(firstName2, testPerson2.FirstName);
            Assert.Equal(lastName2, testPerson2.LastName);
        }

        [Fact]
        public void FindPersonByIdTest()
        {
            //Arrange
            PeopleService testingPeople = new PeopleService();
            Person testPerson1 = testingPeople.AddNewPerson("Janne", "Lindberg");
            Person testPerson2 = testingPeople.AddNewPerson("Anna", "Salin");
            Person testPerson3 = testingPeople.AddNewPerson("Jonas", "Schmidth");
            int checkedPersonId = testPerson2.PersonId;

            //Act
            Person matchedPerson = testingPeople.FindById(checkedPersonId);

            //Assert
            Assert.NotEqual(matchedPerson, testPerson1);
            Assert.Equal(matchedPerson, testPerson2);
            Assert.NotEqual(matchedPerson, testPerson3);
        }

        [Fact]
        public void SizePersonTest()
        {
            //Assert
            PeopleService testingPeople = new PeopleService();
            testingPeople.AddNewPerson("Johanna", "Ljung");
            testingPeople.AddNewPerson("Mona-Lisa", "Larsson");

            int expectedSize = 2;

            //Act
            int actualSize = testingPeople.Size();

            //Assert
            Assert.Equal(expectedSize, actualSize);
        }

        [Fact]
        public void FindAllPeopleTest()
        {
            //Arrange            
            PeopleService testingPeople = new PeopleService();
            testingPeople.Clear();

            testingPeople.AddNewPerson("Janne", "Lindberg");
            testingPeople.AddNewPerson("Anna", "Salin");
            testingPeople.AddNewPerson("Jonas", "Schmidth");
            int expectedSize = 3;
            //Act
            Person[] foundPersons = testingPeople.FindAll();

            //Assert
            Assert.Equal(expectedSize, foundPersons.Length);
        }

        [Fact]
        public void RemovePersonTest()
        {
            //Arrange
            PeopleService testPerson = new PeopleService();

            Person testPerson1 = testPerson.AddNewPerson("Maja", "Ljung");
            Person testPerson2 = testPerson.AddNewPerson("Ludwig", "Hallberg");
            Person testPerson3 = testPerson.AddNewPerson("Anna", "Larsson");


            //Act
            testPerson.RemovePerson(testPerson2.PersonId);

            //Assert
            Assert.Contains(testPerson1, testPerson.FindAll());
            Assert.DoesNotContain(testPerson2, testPerson.FindAll());
            Assert.Contains(testPerson3, testPerson.FindAll());
        }

        //[Fact]

        //public void CreateNewTodoTest()
        //{
        //    //Arrange
        //    TodoItem testingTodo = new TodoItem();
        //    testingTodo.Clear();

        //    string description1 = "Study";
        //    string description2 = "Exercise";
        //    string description3 = "Cook";

        //    //Act
        //    Todo testPerson1 = testingTodo.CreateNewTodo(description1);
        //    Todo testPerson2 = testingTodo.CreateNewTodo(description2);
        //    Todo testPerson3 = testingTodo.CreateNewTodo(description3);

        //    //Assert
        //    Assert.Equal(description1, testPerson1.Description);
        //    Assert.Equal(description2, testPerson2.Description);
        //    Assert.Equal(description3, testPerson3.Description);
        //}

        //[Fact]

        //public void FindTodoByIdTest()
        //{
        //    //Arrange
        //    TodoItem testingTodos = new TodoItem();

        //    Todo testTodo1 = testingTodos.CreateNewTodo("Read");
        //    Todo testTodo2 = testingTodos.CreateNewTodo("Go swimming");
        //    Todo testTodo3 = testingTodos.CreateNewTodo("Finish assignment");
        //    int checkedTodoId = testTodo3.TodoId;

        //    //Act
        //    Todo matchedTodo = testingTodos.FindById(checkedTodoId);

        //    //Assert
        //    Assert.NotEqual(matchedTodo, testTodo2);
        //    Assert.NotEqual(matchedTodo, testTodo2);
        //    Assert.Equal(matchedTodo, testTodo3);
        //}

        [Fact]
        public void TodoSizeTest()
        {
            //Assert

            PeopleService testingPeople = new PeopleService();
            testingPeople.AddNewPerson("Hanna", "Ljung");
            testingPeople.AddNewPerson("Mona", "Lund");

            int expectedSize = 2;

            //Act
            int actualSize = testingPeople.Size();

            //Assert
            Assert.Equal(expectedSize, actualSize);
        }

        [Fact]
        public void FindAllTodosTest()
        {
            //Arrange            
            PeopleService testingPeople = new PeopleService();
            testingPeople.Clear();

            testingPeople.AddNewPerson("Fred", "Lindberg");
            testingPeople.AddNewPerson("Anna", "Molin");
            testingPeople.AddNewPerson("Jens", "Schmidth");
            int expectedSize = 3;
            //Act
            Person[] foundPersons = testingPeople.FindAll();

            //Assert
            Assert.Equal(expectedSize, foundPersons.Length);
        }

        [Fact]
        public void FindByDoneTest()
        {
            //Arrange
            TodoService todoTest = new TodoService();
            todoTest.Clear();

            Todo todo1 = todoTest.AddNewTodo("Go running");
            Todo todo2 = todoTest.AddNewTodo("Relax");
            Todo todo3 = todoTest.AddNewTodo("Finish Assignment");

            todoTest.FindById(todo1.TodoId).Done = true;
            todoTest.FindById(todo2.TodoId).Done = false;
            todoTest.FindById(todo3.TodoId).Done = true;

            //Act
            Todo[] findDones = todoTest.FindByDoneStatus(true);

            //Assert
            for (int i = 0; i < findDones.Length; i++)
            {
                Assert.True(findDones[i].Done);
            }

            Assert.Contains(todo1, findDones);
            Assert.Contains(todo3, findDones);
        }

        [Fact]
        public void TestFindByAssigneeId()
        {
            //Arrange
            int personId = PersonSequencer.NextPersonId();
            Person assignee = new Person("Fred", "Johnsson", personId);

            TodoService testTodos = new TodoService();
            testTodos.Clear();

            Todo todo1 = testTodos.AddNewTodo("Go for a run");
            Todo todo2 = testTodos.AddNewTodo("Sleep");
            Todo todo3 = testTodos.AddNewTodo("Finish the test");
            Todo todo4 = testTodos.AddNewTodo("Watch TV");

            todo1.Assignee = assignee;
            todo2.Assignee = assignee;

            //Act
            Todo[] findAssigneeArray = testTodos.FindByAssignee(personId);

            //Assert
            Assert.Contains(todo1, findAssigneeArray);
            Assert.Contains(todo2, findAssigneeArray);
            Assert.DoesNotContain(todo3, findAssigneeArray);
            Assert.DoesNotContain(todo4, findAssigneeArray);
        }

        [Fact]
        public void FindByAssigneePersonTest()
        {
            //Arrange
            int personId = PersonSequencer.NextPersonId();
            string firstName1 = "Fred";
            string lastName1 = "Johnsson";
            string firstName2 = "Edwin";
            string lastName2 = "Nylén";

            Person assignee1 = new Person(firstName1, lastName1, personId);
            Person expectedAssignee = new Person(firstName2, lastName2, personId);

            TodoService testTodos = new TodoService();
            testTodos.Clear();


            Todo todo1 = testTodos.AddNewTodo("Go for a run");
            Todo todo2 = testTodos.AddNewTodo("Sleep");
            Todo todo3 = testTodos.AddNewTodo("Finish the test");

            todo1.Assignee = assignee1;
            todo2.Assignee = expectedAssignee;
            todo3.Assignee = expectedAssignee;

            //Act
            Todo[] findAssigneeArray = testTodos.FindByAssignee(expectedAssignee);

            //Assert
            Assert.Contains(todo2, findAssigneeArray);
            Assert.Contains(todo3, findAssigneeArray);
            Assert.DoesNotContain(todo1, findAssigneeArray);
        }

        [Fact]
        public void FindUnassignedTodoTest()
        {
            //Arrange
            Person testPerson = new Person("Lotta", "Svensson", PersonSequencer.NextPersonId());
            TodoService testTodos = new TodoService();
            Todo todo1 = testTodos.AddNewTodo("Have a rest");
            Todo todo2 = testTodos.AddNewTodo("Eat");
            Todo todo3 = testTodos.AddNewTodo("Work");
            Todo todo4 = testTodos.AddNewTodo("Study");
            todo1.Assignee = testPerson;
            todo3.Assignee = testPerson;

            //Act
            Todo[] unassignedTodos = testTodos.FindUnassignedTodoItems();

            //Assert
            Assert.Contains(todo2, unassignedTodos);
            Assert.Contains(todo4, unassignedTodos);
            Assert.DoesNotContain(todo1, unassignedTodos);
            Assert.DoesNotContain(todo3, unassignedTodos);
        }

        [Fact]
        public void RemoveTodoTest()
        {
            //Arrange
            TodoService testTodo = new TodoService();

            Todo todo1 = testTodo.AddNewTodo("Eat");
            Todo todo2 = testTodo.AddNewTodo("Sleap");
            Todo todo3 = testTodo.AddNewTodo("Run");

            //Act
            testTodo.RemoveTodo(todo1.TodoId);

            //Assert
            Assert.Contains(todo2, testTodo.FindAll());
            Assert.Contains(todo3, testTodo.FindAll());
            Assert.DoesNotContain(todo1, testTodo.FindAll());
        }

        [Fact]
        public void PersonFullNameTest()
        {
            // Arrange
            string firstName1 = "Emil";
            string lastName1 = "Johansson";
            string firstName2 = "Anders";
            string lastName2 = "Johansson";

            // Act
            Person testPerson1 = new Person(firstName1, lastName1, PersonSequencer.NextPersonId());
            Person testPerson2 = new Person(firstName2, lastName2, PersonSequencer.NextPersonId());

            string fullname1 = testPerson1.fullName;
            string fullname2 = testPerson2.fullName;

            // Assert        
            Assert.Equal("Emil Johansson", fullname1);
            Assert.Equal("Anders Johansson", fullname2);
        }
    }
}