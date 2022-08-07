// example of static classes and methods and members
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpPracticeSyntax
{
    public class BranchingTests
    {
        enum CarColor
        {
            Red = 1,
            Green = 2
        }

        [Fact]
        public void BranchingTest1()
        {
            CarColor color = CarColor.Red;

            string val = color switch
            {
                CarColor.Red => "red",
                CarColor.Green => "green",
                _ => "Color is not red or green!"
            };

            Assert.Equal("red", val);
        }
    }
}