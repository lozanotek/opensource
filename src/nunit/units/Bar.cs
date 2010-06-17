namespace units
{
    using System;

    public class Bar : IBar
    {
        #region IBar Members

        public void PerformAction()
        {
            Console.WriteLine("Action been performed!");
        }

        public int PerformCalculation()
        {
            int result = 2 + 2;
            Console.WriteLine("Calculated 2 + 2 and it's {0}", result);

            return result;
        }

        #endregion
    }
}
