using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllenLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllenLibrary.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //arrange
            Calculator calculator = new Calculator();
            int firstnumber = 2;
            int secondnumber = 3;
            int expected = 5;
            //act
            int actual;
            actual = calculator.Add(firstnumber,secondnumber);

            //assert
            Assert.AreEqual(expected,actual);
//            Assert.Inconclusive("ddddddd");

        }
    }
}