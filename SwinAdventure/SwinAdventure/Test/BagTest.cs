using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
 
namespace SwinAdventure
{
    public class TestBag
    {
        Bag b;
        Bag b1;
        Item shovel = new Item(new string[] {"shovel"},"a shovel", "This is a shovel");
        Item sword = new Item(new string[] { "sword" }, "a sword", "This is a sword");
        Item diamond = new Item(new string[] { "diamond" }, "a diamond", "This is a diamond");
        Item gold = new Item(new string[] { "gold" }, "a gold", "This is a gold");


        [SetUp]
        public void Setup()
        {
            //Bag(string[] ids, string name, string desc)
            b = new Bag(new string[] { "bag" }, "a bag", "This is a bag");
            b1 = new Bag(new string[] { "bag1" }, "a bag1", "This is a bag1");
            b.Inventory.Put(shovel); b.Inventory.Put(sword); //Adding item to bag
            b1.Inventory.Put(diamond); b1.Inventory.Put(gold); //Adding item to bag1


        }

        [Test]
        public void TestBagLocatesItems()
        {
            Assert.IsTrue(b.Inventory.HasItem("sword")); //Check if have item
            Assert.IsTrue(b.Inventory.HasItem("shovel"));

            Assert.IsTrue(b.Locate(sword.FirstID) == sword); //Check if locate item
            Assert.IsTrue(b.Locate(shovel.FirstID) == shovel);

        }

        [Test]
        public void TestBagCantLocatesItems()
        {
            b.Inventory.Take(sword.FirstID);
            Assert.IsFalse(b.Inventory.HasItem("sword")); //Check if have item
            Assert.IsTrue(b.Inventory.HasItem("shovel"));

            Assert.IsFalse(b.Locate(sword.FirstID) == sword); //Check if locate item
            Assert.IsTrue(b.Locate(shovel.FirstID) == shovel);
        }

        [Test]
        public void TestBagLocateItself()
        {
            Assert.IsTrue(b.Locate(b.FirstID) == b);
            Assert.IsTrue(b.Locate("bag") == b);
        }

        [Test]
        public void TestBagLocateNothing()
        {
            Assert.IsTrue(b.Locate(diamond.FirstID) == null);
        }

        [Test]
        public void TestBagFullDesc()
        {
            Assert.AreEqual(b.FullDesciption, "a bag, containing:\na shovel (shovel)\na sword (sword)\n");
        }

        [Test]
        public void TestBagInBag()
        {
            b.Inventory.Put(b1);
            Assert.IsTrue(b.Locate(b1.FirstID) == b1);
            Assert.IsTrue(b.Locate(sword.FirstID) == sword);
            Assert.IsFalse(b.Locate(diamond.FirstID) == diamond);

            Assert.AreEqual(b.FullDesciption, "a bag, containing:\na shovel (shovel)\na sword (sword)\na bag1 (bag1)\n"); //Testing Desc of b
            Assert.AreEqual(b1.FullDesciption, "a bag1, containing:\na diamond (diamond)\na gold (gold)\n"); //Testing Desc of b1


        }

    }
}
