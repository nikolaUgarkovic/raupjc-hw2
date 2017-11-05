using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y = > if x is not null , expression returns x. Else it willreturn y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(s => s.Id == todoId);
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Any(s => s.Equals(todoItem)))
            {
                throw new DuplicateTodoItemException();
            }
            else
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
        }

        public bool Remove(Guid todoId)
        {
            TodoItem item = this.Get(todoId);
            return _inMemoryTodoDatabase.Remove(item);
        }

        public TodoItem Update(TodoItem todoItem)
        {
            TodoItem item = Get(todoItem.Id);
            if (_inMemoryTodoDatabase.Any(s => s.Equals(todoItem)))
            {
                item = todoItem;
                return item;
            }
            else
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem item = this.Get(todoId);
            return item.MarkAsCompleted();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(s => s.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(s => s.IsCompleted == false).OrderByDescending(s => s.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(s => s.IsCompleted == true).OrderByDescending(s => s.DateCreated).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).OrderByDescending(s => s.DateCreated).ToList();
        }


    }
}
