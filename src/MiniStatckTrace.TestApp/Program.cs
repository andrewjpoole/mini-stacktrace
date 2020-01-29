using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sut = new TestClass1();
            sut.InterestingMethodA();

            Console.ReadKey();
        }
    }

    public class TestClass1
    {
        public void InterestingMethodA()
        {
            var x = new TestClass2();
            x.InterestingMethodB();
        }

        public void MethodWhichThrows()
        {
            throw new Exception("Something threw an exception!");
        }
    }
}
