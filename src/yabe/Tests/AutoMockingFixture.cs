namespace Tests
{
    using System;
    using Rhino.Mocks;
    using Rhino.Testing.AutoMocking;

    public class AutoMockingFixture : Fixture
    {
        AutoMockingContainer container;
        MockRepository mocks;

        public MockRepository Mocks
        {
            get { return mocks; }
        }

        public IDisposable Record
        {
            get { return Mocks.Record(); }
        }

        public IDisposable Playback
        {
            get { return Mocks.Playback(); }
        }

        public AutoMockingContainer Container
        {
            get { return container; }
        }


        public override void Setup()
        {
            mocks = new MockRepository();
            container = new AutoMockingContainer(mocks);
            Container.Initialize();

            base.Setup();
        }

        protected TType Stub<TType>()
        {
            return Mocks.Stub<TType>();
        }

        protected TType Stub<TType>(params object[] args)
        {
            return Mocks.Stub<TType>(args);
        }

        protected TType Get<TType>() where TType : class
        {
            return Container.Get<TType>();
        }

        protected TType Create<TType>()
        {
            return Container.Create<TType>();
        }

        protected TType Partial<TType>()
            where TType : class
        {
            return Mocks.PartialMock<TType>();
        }

        protected TType Partial<TType>(params object[] args)
            where TType : class
        {
            return Mocks.PartialMock<TType>(args);
        }

        protected TType Mock<TType>()
        {
            return mocks.DynamicMock<TType>();
        }

        protected TType Mock<TType>(params object[] args)
        {
            return Mocks.DynamicMock<TType>(args);
        }
    }
}
