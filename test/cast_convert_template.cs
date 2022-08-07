// Implicit conversions : No special syntax is required because the conversion is type safe and no data will be lost.
// Examples include conversions from smaller to larger integral types, and conversions from derived classes to base classes.
// Explicit conversions(casts) : Explicit conversions require a cast operator. 
// Casting is required when information might be lost in the conversion, or when the conversion might not succeed for other reasons.
// Typical examples include numeric conversion to a type that has less precision or a smaller range, and conversion of a base - class instance to a derived class.
// User - defined conversions : User - defined conversions are performed by special methods that you can define to enable explicit and implicit conversions between custom types that do not have a base class–derived class relationship.For more information, see Conversion Operators.
// we want to do some ConvertTo calls, mostly to do string to number

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Math;
using System.Reflection;


namespace CSharpPracticeSyntax
{
    public class CastConvertTests
    {
        public class MyBaseClass
        { /**/
            public MyBaseClass()
            {
                val = 0;
            }
            public void Base1()  { } /**/
            public int val;
        }; /**/

        public class MyDerivedClass : MyBaseClass
        {
            public void Derived1() { }
        }; /**/


        [Fact]
        public void FloatToInt()
        {
            // declare a float and then cast it to an int
            float y = 4.5f;
            int x = (int)Math.Truncate(y);
            Assert.Equal(4, x);

            // do a floor and a ceil
            x = (int)Math.Ceiling(y);
            Assert.Equal(5, x);

            x = (int)Math.Floor(y);
            Assert.Equal(4, x);
        }
        [Fact]
        public void CastUpAndDown()
        {
            // allocate a derived object but with a base class pointer
            MyBaseClass b = new MyDerivedClass();
            b.val = 7;
            MyDerivedClass d;

            Type s = b.GetType();
            Assert.Equal("MyDerivedClass", s.Name);

            // cast to a derived pointer.  Both b and d are pointing at the same object.
            d = (MyDerivedClass)b;
            d.val = 9;
            Assert.True(b.Equals(d));

            // call a derived method
            d.Derived1();
        }
        [Fact]
        void AlternateCastingSyntax()
        {
            MyDerivedClass d = new MyDerivedClass();

            MyBaseClass s = d as MyBaseClass; // this can also be used to see if the cast would work

            // the underlying object being pointed to has not changed
            Assert.IsType<MyDerivedClass>(s);
        }
        [Fact]
        void BoxingUnboxing()
        // do a boxing and unboxing of a value
        {
            // declare an int
            int i = 123;
            // box into an object
            object o = i;
            // unbox it back to an integer
            int j = (int)o;
        }

        [Fact]
        void ConvertBetweenNumberAndString()
        {
            string sourcestring;
            int myinteger = 12345;
            float myfloat = 12345.67F;

            sourcestring = myinteger.ToString();/**/

            Assert.Equal(@"12345", sourcestring);

            sourcestring = myfloat.ToString();/**/

            Assert.Equal(@"12345.67", sourcestring);

            // convert a string "5" to an integer 5
            string sfive = "5";
            Int32 ifive = 0;
            ifive = Convert.ToInt32(sfive);/**/
            Assert.Equal(5, ifive);
        }
    }
} /**/