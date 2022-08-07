// an interface with methods and with properties
// An interface defines a contract that can be implemented by classes and structs. An interface can contain methods, properties, events, and indexers. 
// even if interface seems unnecessary it is also useful for unit testing
// An interface does not provide implementations of the members it defines.
// It merely specifies the members that must be supplied by classes or structs that implement the interface.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeSyntax
{
    public class InterfaceTests
    {
        // define an interface
        public interface MyInterface1
        {
            // you would not make virtual or give default implementations.  That is for abstract classes and base classes
            public int Method1();
        }
        // define a second interface and have it have properties not just methods
        public interface MyInterface2
        {
            public int Method2();

            public int Field1 { get; set; }
        }
        // implement both interfaces
        public class MyImplementsInterfaceClass : MyInterface1, MyInterface2
        {
            // you would not override because you would not make the methods virtual in an interface
            public int  Method1()
            {
                return 7;
            }
            public int Method2()
            {
                return 17;
            }
            public int Field1 { get; set; }
        }
        [Fact]
        public void InterfaceTest1()
        {
            var x = new MyImplementsInterfaceClass();
            var y = x as MyInterface1;
            var z = x as MyInterface2;
            Assert.NotNull(y);
            z.Field1 = 2;
            Assert.Equal(2, z.Field1);
            Assert.Equal(7, y.Method1());
            Assert.Equal(17, z.Method2());
        }
    }
}