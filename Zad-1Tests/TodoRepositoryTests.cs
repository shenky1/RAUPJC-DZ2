using Microsoft.VisualStudio.TestTools.UnitTesting;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Tests
{ 
        [TestClass]
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
        }
    }