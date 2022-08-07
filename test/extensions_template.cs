// example complex branching like ternary and switch
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpPracticeSyntax
{
    public class MyTestClass
    {
        public int val { get; set; }
    }
    public static class MyTestClassExtensions
    {
        public static void SetVal(this MyTestClass cl, int updatedVal)
        {
            cl.val = updatedVal;
        }
    }
    public class ExtensionsTests
    {
        [Fact]
        public void ExtensionsTest1()
        {
            var x = new MyTestClass();
            x.SetVal(7);
            Assert.Equal(7, x.val);
        }
    }
}