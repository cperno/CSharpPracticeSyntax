//Throwing and catching exceptions
// catch everything but use a where clause
// just call throw vs rethrowing the caught exception
// 
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace CSharpPracticeSyntax
{
    public class ExceptionTesting
    {
        // create an exception class
        public class MyExceptionClass : Exception
        {
            public int AdditionalInformation { get; set; }
        }

        static int GetLineNumber([System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0)
        {
            return lineNumber;
        }
        // throw that an object of that class, including the callstack and a message

        // catch that object using different ways of catching, including parent classes

        // rethrow and catch and make sure the inner exception is in there
        [Fact]
        public void ExceptionTest1()
        {
            try
            {
                int x = 1;
            }
            catch (MyExceptionClass e)
            {
                Assert.Equal(7, e.AdditionalInformation);
            }
            finally
            {
                // this is still executed if we did not catch exception
                Console.WriteLine("in the finally");
            }

            try
            {
                throw new MyExceptionClass() { AdditionalInformation = 7 };
            }
            catch (MyExceptionClass e)
            {
                Assert.Equal(7, e.AdditionalInformation);
            }
            finally
            {
                // this is still executed even if we caught exception
                Console.WriteLine("in the finally");
            }

            try
            {
                throw new MyExceptionClass() { AdditionalInformation = 7 };
            }
            catch (Exception e) when (e.GetType().Name == "MyExceptionClass") // you might look at other thing than name
            {
                Assert.Equal(7, (e as MyExceptionClass).AdditionalInformation);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().ToString());
            }

        }

        [Fact]
        public void ExceptionRethrowOriginalTest1()
        {
            int lineNumber=-999;
            try
            {
                try
                {
                    lineNumber = GetLineNumber();
                    throw new MyExceptionClass() { AdditionalInformation = lineNumber };
                }
                catch (MyExceptionClass e)
                {
                    throw;  // rethrow the caught exception, unchanged
                }
            }
            catch (Exception e)
            {
                Assert.Null(e.InnerException);
                Assert.Contains(Convert.ToString(lineNumber+1), e.StackTrace);
            }
        }
        [Fact]
        public void ExceptionRethrowTest1()
        {
            int lineNumber = -999;
            try
            {
                try
                {
                    throw new MyExceptionClass() { AdditionalInformation = 7 };
                }
                catch (MyExceptionClass e)
                {
                    Assert.Equal(7, e.AdditionalInformation);
                    lineNumber = GetLineNumber();
                    throw e;  // rethrow the caught exception but from our line
                }
            }
            catch (Exception e)
            {
                Assert.Null(e.InnerException);
                Assert.Contains(Convert.ToString(lineNumber + 1), e.StackTrace);
            }
        }
        [Fact]
        public void ExceptionRethrowTest2()
        {
            try
            {
                try
                {
                    throw new MyExceptionClass() { AdditionalInformation = 7 };
                }
                catch (MyExceptionClass e)
                {
                    Assert.Equal(7, e.AdditionalInformation);
                    throw new Exception("myrethrow",e);  // rethrow the caught exception as inner
                }
            }
            catch (Exception e)
            {
                Assert.NotNull(e.InnerException);
            }
        }
    }
}