// checking if a string is in the enum
// getting the list of strings
// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeSyntax
{
    public class EnumTests
    {
        enum MyColorEnum
        {
            Red = 1,
            Green = 2,
            Blue = 3
        }

        // see if the value is in the enum
        [Fact]
        public void EnumContainsItem()
        {
            // you can lookup keys
            Assert.True(Enum.IsDefined(typeof(MyColorEnum), "Red"));
            // you can lookup values
            Assert.True(Enum.IsDefined(typeof(MyColorEnum), 1));
        }

        // Get all the values
        [Fact]
        public void GetEnumItem()
        {
            Assert.Contains("Red", Enum.GetNames(typeof(MyColorEnum)));
        }
    }
}