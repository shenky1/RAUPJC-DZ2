using Microsoft.VisualStudio.TestTools.UnitTesting;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullToDatabaseThrowsException()
        {
            ITodoRepository repository = new TodoRepository();
            repository.Add(null);
        }
        [TestMethod]
        public void AddingItemWillAddToDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsTrue(repository.Get(todoItem.Id) != null);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void AddingExistingItemWillThrowException()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            repository.Add(todoItem);
        }


        [TestMethod()]
        public void GetTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            var item = repository.Get(todoItem.Id);
            Assert.AreEqual(todoItem, item);
        }

        [TestMethod()]
        public void GetActiveTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            todoItem.MarkAsCompleted();
            repository.Add(todoItem);
            var active = repository.GetActive();
            Assert.AreEqual(0, active.Count);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem2 = new TodoItem(" BOK ");
            todoItem.MarkAsCompleted();
            repository.Add(todoItem);
            repository.Add(todoItem2);
            var active = repository.GetAll();
            Assert.AreEqual(2, active.Count);
            Assert.AreEqual(active.IndexOf(todoItem), 0);
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem2 = new TodoItem(" BOK ");
            todoItem.MarkAsCompleted();
            repository.Add(todoItem);
            repository.Add(todoItem2);
            var completed = repository.GetCompleted();
            Assert.AreEqual(1, completed.Count);
            Assert.AreEqual(completed.ElementAt(0), todoItem);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            var todoItem2 = new TodoItem(" BOK ");
            todoItem.MarkAsCompleted();
            repository.Add(todoItem);
            repository.Add(todoItem2);
            var boole = repository.Remove(todoItem2.Id);
            Assert.AreEqual(true, boole);
        }
    }
}