//You use the const keyword to declare a constant field or a constant local. Constant fields and locals aren't variables and may not be modified. 
// Constants can be numbers, Boolean values, strings, or a null reference. Don’t create a constant to represent information that you expect to change at any time. 
// For example, don’t use a constant field to store the price of a service, a product version number, or the brand name of a company. 
// These values can change over time, and because compilers propagate constants, other code compiled with your libraries 
// will have to be recompiled to see the changes. See also the readonly keyword. For example:
// const int X = 0;
// public const double GravitationalConstant = 6.673e-11;
// private const string ProductName = "Visual C#";

// The static modifier is not allowed in a constant declaration but you can use in readonly

// The readonly keyword is a modifier that can be used in three contexts:
// #1 In a field declaration, readonly indicates that assignment to the field can only occur as part of the declaration or in a constructor in the same class.
// #2 In a readonly struct definition, readonly indicates that the struct is immutable.
// #3 In a ref readonly method return, the readonly modifier indicates that method returns a reference and writes are not allowed to that reference.
// The final two contexts were added in C# 7.2.

// const is set at compile time.  a readonly is set at runtime
// either way, once set you can't change it.
// a readonly is a variable.  A const it not

// you can also make read only by not having a write accessor

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpPracticeSyntax
{
    public class ConstAndReadOnlyTests
    {
        // we create a class with 2 read only fields, one set at compile time and one set in the constructor.
        class SampleReadonlyClass
        {
            public int x;
            // Initialize a readonly (an immutable) field
            public readonly int y = 25;
            public readonly int z;

            public int readonlyproperty { get; }  // do not put a set
            public SampleReadonlyClass()
            {
                // Initialize a readonly instance field
                z = 24;
                readonlyproperty = 7;
            }
        }
        [Fact]
        public void Test1()
        {
            // declare a const to be used in the rest of the program

            const int NUM_BOOKS = 7;
            int[] myarray = new int[NUM_BOOKS];

            // set a read only property at construction time
            var x = new SampleReadonlyClass();
            int y = x.readonlyproperty;
            // try to set a read only property after construction time
            //x.readonlyproperty = 8;  this fails because read only
        }
    }
} /**/