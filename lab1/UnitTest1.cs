using System;
using System.Collections.Generic;
using lab1;
using NUnit.Framework;

namespace Project1.UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase(typeof(DivideByZeroException), true)]
        [TestCase(typeof(OutOfMemoryException), true)]
        [TestCase(typeof(StackOverflowException), true)]
        [TestCase(typeof(InsufficientMemoryException), true)]
        [TestCase(typeof(InsufficientExecutionStackException), true)]

        [TestCase(typeof(ArgumentNullException), false)]
        [TestCase(typeof(ArgumentOutOfRangeException), false)]
        [TestCase(typeof(NullReferenceException), false)]
        [TestCase(typeof(AccessViolationException), false)]
        [TestCase(typeof(IndexOutOfRangeException), false)]
        [TestCase(typeof(InvalidOperationException), false)]
        public void Check_if_is_critical_criticality_Correct(Type exceptionType, bool expectedResult)
        {
          // arrange: об'єктів, тобто створення і налаштування.
          var instance = (Exception)Activator.CreateInstance(exceptionType);
            try
            {
                // act: на об'єкт.
                throw instance;
            }
            catch (Exception e)
            {
                // assert: про очікуваний результат.
                Assert.AreEqual(expectedResult, new Lab1().is_critical(e));
                return;
            }
        }

        [Test]
        public void Count_exceptions_counter_values_correct()
        {
            // arrange: об'єктів, тобто створення і налаштування.
            var criticalexceptions = new List<Type>()
                  {
                    typeof(DivideByZeroException),
                    typeof(OutOfMemoryException),
                    typeof(StackOverflowException),
                    typeof(InsufficientMemoryException),
                    typeof(InsufficientExecutionStackException)};

            var notcriticalexceptions = new List<Type>()
                  { typeof(ArgumentNullException),
                    typeof(ArgumentOutOfRangeException),
                    typeof(NullReferenceException),
                    typeof(AccessViolationException),
                    typeof(IndexOutOfRangeException),
                    typeof(InvalidOperationException)};

            var lab1 = new Lab1();

            // act: на об'єкт.
            foreach (var item in criticalexceptions)
            {
                var instance = (Exception)Activator.CreateInstance(item);
                lab1.CountExceptions(instance);
            }
            foreach (var item in notcriticalexceptions)
            {
                var instance = (Exception)Activator.CreateInstance(item);
                lab1.CountExceptions(instance);
            }

            // assert: про очікуваний результат.
            Assert.AreEqual(lab1.counter_exceptions_critical,criticalexceptions.Count);
            Assert.AreEqual(lab1.regular_exceptions_counter,notcriticalexceptions.Count);
        }

        [Test]
        public void CountExceptions_InitCounters_Zero()
        {
            // arrange: об'єктів, тобто створення і налаштування.
            var lab1 = new Lab1();

            // assert: про очікуваний результат.
            Assert.AreEqual(lab1.counter_exceptions_critical,0);
            Assert.AreEqual(lab1.regular_exceptions_counter,0);
        }
    }
}