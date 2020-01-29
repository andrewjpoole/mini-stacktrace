using System;

namespace TestApp
{
    public class TestClass2
    {
        public void InterestingMethodB()
        {
            Console.WriteLine(MiniStackTrace.MiniStackTrace.Get());
        }
    }
}
