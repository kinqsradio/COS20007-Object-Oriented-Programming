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
            Assert.AreEqual("00:00:00", _clock.CurrentTime());

        }

        [TestCase(0,"00:00:00")]
        [TestCase(60, "00:01:00")]
        [TestCase(120, "00:02:00")]
        [TestCase(86340, "23:59:00")]

        public void TestRunning(int tick, string currenttime)
        {
            int i;
            for (i = 0; i < tick; i++)
            {
                _clock.Tick();
            }
            Assert.AreEqual(currenttime, _clock.CurrentTime());

        }

        [TestCase("00:01:00", "00:00:59")] //Roll to 1 min
        [TestCase("01:00:00", "00:59:59")] //Roll to 1 hr
        [TestCase("00:00:00", "23:59:59")] //Roll to 1 day
        public void TestClockRollover(string exp, string settime)
        {
            _clock.SetTime(settime);
            _clock.Tick();
            Assert.AreEqual(exp, _clock.CurrentTime());
        }
    }
}
