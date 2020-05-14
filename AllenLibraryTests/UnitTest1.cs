using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace AllenLibraryTests
{


    [TestClass]
    public class UnitTest1
    {
        public interface ICalculator
        {
            int Add(int a, int b);

        }
        [TestMethod]
        public void TestMethod1()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(3, 6).Returns(9);
            var expected = 9;
            var actual = calculator.Add(3,6);

            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void Test_calculator2() {
            ICalculator calculator = Substitute.For<ICalculator>();

            //calculator.Add(Arg.Any<int>(), 5).Returns(10);
            //Assert.AreEqual(10, calculator.Add(333, 5));

            //calculator.Add(1,Arg.Is<int>(x => x < 0)).Returns(444);
            //Assert.AreEqual(444,calculator.Add(1,-4));
            //Assert.AreNotEqual(444, calculator.Add(1, 1));

            //calculator.Add(2, 2).ReturnsForAnyArgs(100);
            //Assert.AreEqual(calculator.Add(2,1),100);

            calculator.Add(Arg.Any<int>(), Arg.Any<int>()).Returns(x=> (int)x[0]+(int)x[1]);

            
            //Assert.AreEqual(calculator.Add(2,4), Is.EqualTo(6));
                
        }
        public interface ICommand
        {
            void Execute();
            event EventHandler  Executed;
        }
        public class SomethingThatNeed
        { 
            ICommand command;
            public SomethingThatNeed(ICommand command)
            {
                this.command = command;

            }
            public void DoSomeThing() { command.Execute(); }
            public void NotDoAnything() { }
        }

        [TestMethod]
        public void Do_test()
        {
            var command = Substitute.For<ICommand>();
            var dosomething = new SomethingThatNeed(command);
            dosomething.DoSomeThing();
            command.Received().Execute();
         }

        [TestMethod]
        public void Do_Test_II()
        {

            var command = Substitute.For<ICommand>();
            var NotDoSomething = new SomethingThatNeed(command);
            NotDoSomething.NotDoAnything();
            command.DidNotReceive().Execute();

        }
        public void Te() { }

    }
}
