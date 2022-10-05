using System;
using NUnit.Framework;

namespace SwinAdventure
{
    public class PathTest
    {
        Player _testPlayer;
        Location _testRoomA;
        Location _testRoomB;
        Path _testPath;

        [Test]
        public void TestPathLocation()
        {
            _testPlayer = new Player("Danny", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            Location _expected = _testRoomB;
            Location _actual = _testPath.Destination;

            Assert.AreEqual(_expected, _actual);
        }

        [Test]
        public void TestPathName()
        {
            _testPlayer = new Player("Danny", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            string _expected = "A test door";
            string _actual = _testPath.FullDesciption;

            Assert.AreEqual(_expected, _actual);
        }

        [Test]
        public void TestLocatePath()
        {
            _testPlayer = new Player("Danny", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            GameObject _expected = _testRoomA.Locate("north");
            GameObject _actual = _testPath;

            Assert.AreEqual(_expected, _actual);
        }
    }
}

//                return $"\nYou are at {_name}\nRoom Description: {_desc}\n\nItems at this location:\n{Inventory.ItemList}";

