namespace UnitTesting.Tests.Fundamentals
{
    [TestClass]
    public class StackTest
    {
        private Stack<int> _s = new Stack<int>();


        [TestMethod]
        public void Push_WhenElementIsValid_ElementIsAdded()
        {
            int element = 1;

            _s.Push(element);
            Assert.IsTrue(_s.Contains(element));
            Assert.IsTrue(_s.Count != 0);
            _s.Clear();
        }

        [TestMethod]
        public void Pop_WhenListIsNotEmpty_ReturnsElementAndDeletesIt()
        {
            _s.Push(1);

            int countBefore = _s.Count;
            int one = _s.Pop();
            int countAfter = _s.Count;
            Assert.IsTrue(one == 1);
            Assert.IsTrue(countBefore - 1 == countAfter);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ListIsEmpty_ReturnsInvalidOperationException()
        {
            int countBefore = _s.Count;
            int element = _s.Pop();
            int countAfter = _s.Count;
            Assert.IsTrue(element == 1);
            Assert.IsTrue(countBefore - 1 == countAfter);
        }

        [TestMethod]
        public void Peek_WhenListIsNotEmpty_ReturnsElemnt()
        {
            _s.Push(1);

            int countBefore = _s.Count;
            int element = _s.Peek();
            int countAfter = _s.Count;

            Assert.IsTrue(countAfter == countBefore);
            Assert.IsTrue(element == 1);
        }

    }
}
