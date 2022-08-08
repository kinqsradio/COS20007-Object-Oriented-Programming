using NUnit.Framework;

namespace Clock
{
    public class ClockTest
    {
        Clock _clock;

        [SetUp]
        public void Setup()
        {
           _clock = new Clock();
        }

        [Test]
        public void TestClockStart()
        {
            Assert.AreEqual("00:00:00", _clock.CurrentTime());
        }

        [Test]
        public void TestReset()
        {
            int i;
            for (i = 0; i < 86400; i++)
            {
                _clock.Tick();
            }
            _clock.Reset();
        }

        [TestCase(0,"00:00:00")]
        [TestCase(60, "00:01:00")]
        [TestCase(120, "00:02:00")]
        public void TestRunning(int tick, string currenttime)
        {
            int i;
            for (i = 0; i < tick; i++)
            {
                _clock.Tick();
            }
            Assert.AreEqual(currenttime, _clock.CurrentTime());

        }
    }
}
