using NUnit.Framework;

namespace Clock
{
    public class TestCounter
    {
        Counter _countertest;

        [SetUp]
        public void Setup()
        {
            _countertest = new Counter("Test");
        }

        [Test]
        public void test_name()
        {
            Assert.AreEqual("Test", _countertest.Name);
        }

        [Test]
        public void test_count_reset()
        {
            _countertest.Increment();
            _countertest.Reset();
            Assert.AreEqual(0, _countertest.Tick);
        }

        [TestCase(100,100)]
        public void test_increment(int tick, int result)
        {
            int i;
            for(i=0; i<tick; i++)
            {
                _countertest.Increment();
            }
            Assert.AreEqual(result, _countertest.Tick);
        }
    }
}
