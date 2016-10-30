using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class TodoRepository : ITodoRepository
    {
            /// <summary >
            /// Repository does not fetch todoItems from the actual database ,
            /// it uses in memory storage for this excersise .
            /// </ summary >
        private readonly List<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(List<TodoItem> initialDbState = null)
            {
                if (initialDbState != null)
                {
                    _inMemoryTodoDatabase = initialDbState;
                }
                else
                {
                    _inMemoryTodoDatabase = new List<TodoItem>();
                }
            }
        public void Add(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException();
            }
            if (Equals(Get(todoItem.Id), todoItem))
            {
                throw new DuplicateTodoItemException("duplicate id: {" + todoItem.Id.ToString() + "}");
            }
            _inMemoryTodoDatabase.Add(todoItem);
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(i => i.Id == todoId);
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i => !i.IsCompleted).ToList();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(i => i.IsCompleted).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();

        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem item = Get(todoId);
            item.MarkAsCompleted();
            return item.IsCompleted;
        }

        public bool Remove(Guid todoId)
        {
            return _inMemoryTodoDatabase.Remove(Get(todoId));
        }

        public void Update(TodoItem todoItem)
        {
            if (Get(todoItem.Id) == null) Add(todoItem);
            else
            {
                var item = Get(todoItem.Id);
                item = todoItem;
            }
        }

    }
}
