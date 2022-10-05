using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;

namespace SwinAdventure
{
    public class LookCommandTest
    {
        Command look;
        Player player, player1;
        Bag bag;

        Item gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
        Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
        Item diamond = new Item(new string[] { "diamond" }, "a diamond", "This is a diamond");

        [SetUp]
        public void Setup()
        {
            look = new LookCommand();
            player = new Player("Anh", "Anh's Player"); //Set up player
            bag = new Bag(new string[] { "bag" },
                $"Anh's bag",
                $"This is {player.FirstID} bag"); //Set up player bag
            player.Inventory.Put(bag);


            player1 = new Player("Anh", "Anh's Player"); //Player with no bag


        }

        [Test]
        public void TestLookAtMe()
        {
            string Output = look.Execute(player, new string[] { "look", "at", "inventory" });
            string exp = $"You are {player.Name}, you are carrying\n{player.Inventory.ItemList}";
            Assert.AreEqual(exp, Output);
        }

        [Test]
        public void TestLookAtGem()
        {
            player.Inventory.Put(gem);

            string Output = look.Execute(player, new string[] { "look", "at", "gem" });
            string exp = $"{gem.FullDesciption}";
            Assert.AreEqual(exp, Output);
        }

        [Test]
        public void TestLookAtUnk()
        {
            string Output = look.Execute(player, new string[] { "look", "at", "gem" });
            string exp = $"Couldn't find gem";
            Assert.AreEqual(exp, Output);
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            player.Inventory.Put(gem);
            string Output = look.Execute(player, new string[] { "look", "at", "gem", "in", "me" });
            string exp = $"{gem.FullDesciption}";
            Assert.AreEqual(exp, Output);
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            bag.Inventory.Put(gem);
            string Output = look.Execute(player, new string[] { "look", "at", "gem", "in", $"bag" });
            string exp = $"{gem.FullDesciption}";
            Assert.AreEqual(exp, Output);
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            bag.Inventory.Put(gem);
            string Output = look.Execute(player, new string[] { "look", "at", "iron", "in", $"bag" });
            string exp = $"Couldn't find iron";
            Assert.AreEqual(exp, Output);
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            bag.Inventory.Put(gem);
            player1.Inventory.Put(bag);
            string Output = look.Execute(player1, new string[] { "look", "at", "gem", "in", $"{player.FirstID}" });
            string exp = $"Couldn't find gem";
            Assert.AreEqual(exp, Output);
        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.AreEqual(look.Execute(player1, new string[] { "look", "around" }), "Error in look input.");
            Assert.AreEqual(look.Execute(player1, new string[] { "find", "gem" }), "Error in look input.");
        }

    }
}