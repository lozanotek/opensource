namespace unittesting
{
    using System;
    using NUnit.Framework;
    using Rhino.Mocks;
    using units;

    [TestFixture]
    public class FooTestFixture
    {
        #region Creation Tests

        [Test]
        public void Can_Create_Instance_With_Homemade_Mock()
        {
            var foo = new Foo(new BarMock());
            Assert.IsNotNull(foo);
        }

        [Test]
        public void Can_Create_Instance_With_Mock()
        {
            var repository = new MockRepository();
            var bar = repository.DynamicMock<IBar>();

            var foo = new Foo(bar);
            Assert.IsNotNull(foo);
        }

        [Test]
        public void Can_Create_Instance_With_Real()
        {
            var foo = new Foo(new BarMock());
            Assert.IsNotNull(foo);
        }

        #endregion

        #region DoAction Tests

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Call_DoAction_With_Null_Bar()
        {
            var foo = new Foo(null);
            foo.DoAction();
        }

        [Test]
        public void Call_DoAction_With_Homemade_Mock()
        {
            var foo = new Foo(new BarMock());
            foo.DoAction();
        }

        [Test]
        public void Call_DoAction_With_Mock()
        {
            var repository = new MockRepository();
            var bar = repository.DynamicMock<IBar>();

            using (repository.Record())
            {
                Expect.Call(bar.PerformAction);
                LastCall.IgnoreArguments();
            }

            using (repository.Playback())
            {
                var foo = new Foo(bar);
                foo.DoAction();
            }
        }

        #endregion

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Call_GetMessage_With_Null_Bar()
        {
            var foo = new Foo(null);
            foo.GetMessage();
        }

        [Test]
        public void Call_GetMessage_With_Homemade_Mock()
        {
            var foo = new Foo(new BarMock());
            string message = foo.GetMessage();
            int index = message.IndexOf("0");

            Assert.AreNotEqual(index, -1);
        }

        [Test]
        public void Call_GetMessage_With_Mock()
        {
            var repository = new MockRepository();
            var bar = repository.DynamicMock<IBar>();

            using (repository.Record())
            {
                Expect.Call(bar.PerformCalculation()).Return(10);
                LastCall.IgnoreArguments();
            }

            var foo = new Foo(bar);
            string message = foo.GetMessage();
            int index = message.IndexOf("10");
            Assert.AreNotEqual(index, -1);
        }
    }

    internal class BarMock : IBar
    {
        #region IBar Members

        public void PerformAction()
        {
        }

        public int PerformCalculation()
        {
            return 0;
        }

        #endregion
    }
}