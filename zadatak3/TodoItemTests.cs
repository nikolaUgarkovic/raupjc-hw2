using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak2;

namespace zadatak3
{
    [TestClass]
    public class TodoItemTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            TodoItem item = new TodoItem("bla");

            item.MarkAsCompleted();

            Assert.AreEqual(true, item.IsCompleted);
            TodoItem item2 = new TodoItem("blabla");

            TodoItem item3 = new TodoItem("blabla");

            Assert.AreEqual(false, item2.Equals(item3));

            item3.Id = item2.Id;

            Assert.AreEqual(true, item2.Equals(item3));
            TodoItem item4 = new TodoItem("baba");

            TodoItem item5 = new TodoItem("baba");

            Assert.IsFalse(item4.GetHashCode() == item5.GetHashCode());

            item5.Id = item4.Id;

            Assert.IsTrue(item4.GetHashCode() == item5.GetHashCode());


        }


    }
}
