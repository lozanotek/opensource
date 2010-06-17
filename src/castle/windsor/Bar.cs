namespace windsor
{
    using System;
    using System.ComponentModel;

    internal class Bar : IBar, ISupportInitialize, IDisposable
    {
        private readonly DateTime dt;

        public Bar()
        {
            dt = DateTime.Now;
        }

        #region IBar Members

        public void DisplayTime()
        {
            Console.WriteLine("It was {0} when I was created.", dt);
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Console.WriteLine("I am being released now.");
        }

        #endregion

        #region ISupportInitialize Members

        public void BeginInit()
        {
            Console.WriteLine("Starting initialization.");
        }

        public void EndInit()
        {
            Console.WriteLine("Ending initialization.");
        }

        #endregion
    }
}