using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak2;

namespace zadatak3
{
    [TestClass]
    public class TodoRepositoryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            ITodoRepository repository = new TodoRepository();
            TodoItem item1 = new TodoItem("prvi");
            Assert.AreEqual(item1, repository.Add(item1));
            Assert.AreEqual(item1, repository.Get(item1.Id));
            Assert.AreEqual(true, repository.Remove(item1.Id));
            TodoItem item2 = new TodoItem("mama");
            repository.Add(item2);
            item2.Text = "tata";
            Assert.AreEqual(item2, repository.Update(item2));
            bool mark = repository.MarkAsCompleted(item2.Id);
            Assert.AreEqual(mark, true);
            repository.Add(new TodoItem("baka"));
            Assert.AreEqual(repository.GetAll().Count, 2);
            repository.MarkAsCompleted(item2.Id);
            Assert.AreEqual(repository.GetActive().Count, 1);
            Assert.AreEqual(repository.GetCompleted().Count, 1);
            Func<TodoItem, bool> funkcija = s => s.Text.StartsWith("b");
            Assert.AreEqual(repository.GetFiltered(funkcija).Count, 1);
        }
    }
}
