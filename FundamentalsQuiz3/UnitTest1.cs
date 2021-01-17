using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FundamentalsQuiz3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public string Question7(string anotherName)
        {
            return ($"Hello, {anotherName}");
        }
    }

    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public double Question10 (DateTime birthday)
        {
            Console.WriteLine($"You are {DateTime);
        }
    }
}