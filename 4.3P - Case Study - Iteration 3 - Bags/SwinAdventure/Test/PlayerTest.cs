using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SwinAdventure
{
    public class TestPlayer
    {
        Player player = new Player("Anh", "Swinburne Student");
        Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
        Item sword = new Item(new string[] { "sword" }, "a sword", "This is a Sword");
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestPlayerIdentifiable()
        {
            Assert.IsTrue(player.AreYou("me") && player.AreYou("inventory"));

        }

        [Test]
        public void TestPlayerLocateItems()
        {
            var result = false;
            player.Inventory.Put(sword);
            var itemsLocated = player.Locate("sword");
            if (sword == itemsLocated)
            {
                result = true;
            }
            Assert.IsTrue(result);
        }

        [Test]
        public void TestPlayerLocateItself()
        {
            var me = player.Locate("me");
            var inv = player.Locate("inventory");
            var result = false;

            if (me == player || inv == player)
            {
                result = true;
            }
            Assert.IsTrue(result);
        }

        [Test]
        public void TestPlayerLocateNothing()
        {
            var me = player.Locate("Hi");
            Assert.IsNull(me);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            player.Inventory.Put(sword);
            player.Inventory.Put(shovel);
            string expected = "Anh, you are carrying:\na sword (sword)\na shovel (shovel)\n";
            Assert.AreEqual(player.FullDesciption, expected);
        }
    }
}