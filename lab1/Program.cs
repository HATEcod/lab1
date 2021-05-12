using System;
using System.Collections.Generic;

namespace lab1
{
    public class Lab1
    {
        public int counter_exceptions_critical{
            get;
            private set;
        }

        public int regular_exceptions_counter{
             get;
            private set;
        }

        static void Main(string[] args)
        {

        }

        public bool is_critical(Exception exception)
        {
            var critical_Exceptions = new List<Type>()
              {
                typeof(DivideByZeroException),
                typeof(OutOfMemoryException),
                typeof(StackOverflowException),
                typeof(InsufficientMemoryException),
                typeof(InsufficientExecutionStackException)
              };
            return critical_Exceptions.Contains(exception.GetType());
        }

        public void CountExceptions(Exception exception)
        {
            if (is_critical(exception))
            {
                counter_exceptions_critical += 1;
            }
            else
            {
                regular_exceptions_counter += 1;
            }
        }
    }
}
