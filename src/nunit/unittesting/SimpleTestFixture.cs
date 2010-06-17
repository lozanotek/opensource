namespace unittesting
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SimpleTestFixture
    {
        #region Setup/Teardown

        [TearDown]
        public virtual void TearDown()
        {
            Console.WriteLine("After test!");
        }

        [SetUp]
        public virtual void Setup()
        {
            Console.WriteLine("Before test!");
        }

        #endregion

        [Test]
        public void Simple_Bad_Unit_Test()
        {
            Assert.AreEqual(-1, 1, "I don't think this is right...");
        }

        [Test]
        public void Simple_Good_Unit_Test()
        {
            Assert.AreEqual(1, 1, "Aallllrrrriiiigggght!");
        }

        [Test]
        [ExpectedException(typeof (InvalidOperationException))]
        public void Simple_Unit_Test_With_Expected_Exception()
        {
            throw new InvalidOperationException("We weren't expecting this!");
        }

        [Test]
        public void Simple_Unit_Test_With_Ignore_Exception()
        {
            throw new InvalidOperationException("We weren't expecting this!");
        }

        [Test]
        public void Simple_Unit_Test_With_Uncaught_Exception()
        {
            throw new InvalidOperationException("We weren't expecting this!");
        }
    }
}