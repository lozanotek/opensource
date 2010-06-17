namespace units
{
    public class Foo : IFoo
    {
        private readonly IBar bar;

        public Foo(IBar bar)
        {
            this.bar = bar;
        }

        #region IFoo Members

        public void DoAction()
        {
            bar.PerformAction();
        }

        public string GetMessage()
        {
            return string.Format("Called IBar and got this result: {0}", bar.PerformCalculation());
        }

        #endregion
    }
}