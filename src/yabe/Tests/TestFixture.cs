namespace Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class Fixture
    {
        [TearDown]
        public virtual void TearDown()
        {
            AfterTest();
        }

        [SetUp]
        public virtual void Setup()
        {
            BeforeTest();
        }

        protected virtual void BeforeTest() { }

        protected virtual void AfterTest() { }
    }
}