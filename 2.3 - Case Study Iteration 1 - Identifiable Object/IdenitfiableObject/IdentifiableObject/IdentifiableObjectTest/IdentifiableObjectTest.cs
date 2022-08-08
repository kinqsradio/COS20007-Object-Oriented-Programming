using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using IdentifiableObject;

 
namespace IdentifiableObject
{
    public class IdentifiableObjectTest
    {

        private IdentifiableObject _testObject;
        private string _testString;
        private string[] _testArray;


        [SetUp]
        public void Setup()
        {
            _testString = "Anh";
            _testArray = new string[] { "Anh", "Bob" };
            _testObject = new IdentifiableObject(_testArray);
            _testObject.AddIdentifier(_testString);
        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(_testObject.AreYou(_testString));
        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.IsFalse(_testObject.AreYou("Max"));
        }

        [Test]
        public void Insensitive()
        {

            Assert.IsTrue(_testObject.AreYou("ANH"));
        }

        [Test]
        public void FirstIDandAddID()
        {
            _testObject.AddIdentifier("Max");
            _testObject.AddIdentifier("Andrew");
            Assert.AreEqual("anh", _testObject.FirstID);
            Assert.AreNotEqual("max", _testObject.FirstID);

            //Test Add Identifier
            Assert.IsTrue(_testObject.AreYou("Max"));
            Assert.IsTrue(_testObject.AreYou("Andrew"));

        }
    }
}
