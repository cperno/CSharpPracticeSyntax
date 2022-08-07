// polymorphism demonstrated with factory
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeSyntax
{
    public class PolymorphismTests
    {
        public enum ShapeType
        {
            Circle = 1,
            Square =2
        }
        // define an interface
        public interface MyShapeInterface
        {
            public int Area();
        }

        // implement an interface
        public class MyShapeCircle : MyShapeInterface
        {
            public int Area()
            {
                return 7;
            }
        }
        public class MyShapeSquare : MyShapeInterface
        {
            public int Area()
            {
                return 15;
            }
        }
        public static class ShapeFactory
        {
            public static MyShapeInterface CreateShape(ShapeType t)
            {
                switch (t)
                {
                    case ShapeType.Circle:
                        return new MyShapeCircle();
                    case ShapeType.Square:
                        return new MyShapeSquare();
                    default: 
                        return null;
                }
            }
        }
        [Fact]
        public void PolymorphismTest1()
        {
            MyShapeInterface c = ShapeFactory.CreateShape(ShapeType.Circle);
            MyShapeInterface s = ShapeFactory.CreateShape(ShapeType.Square);
            Assert.Equal(7, c.Area());
            Assert.Equal(15, s.Area());
        }
    }
}