// creating a tuple
// having a function return a tuple
// accessing elements of a tuple
//
// shows how to make pairs and tuples and put them in containers and sort them.

//Q: why would you use a pair instead of a tuple of size 2?
//A: It is akward to access the members via std::get when you can just do pair.first and second.
//Q: What header contains the pair template?
//A: utility

// not demonstrated yet
// how to discover the type of each field in a tuple at compile time? 
//using my_tuple = std::tuple<int, bool, char>;
//static_assert(std::is_same<std::tuple_element<0, my_tuple>::type, int>::value, "!");
//static_assert(std::is_same<std::tuple_element<1, my_tuple>::type, bool>::value, "!");
//static_assert(std::is_same<std::tuple_element<2, my_tuple>::type, char>::value, "!");
// not sure if you can discover them at runtime.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeSyntax
{
    public class TupleTests
    {
        private Tuple<int,int> FindMinOf3rd(Tuple<string, double, int>[] incoming)
        {
            int min = int.MaxValue;
            int pos = 0;
            int index = 0;

            foreach (var t in incoming)
            {
                if (t.Item3 < min)
                {
                    min = t.Item3;
                    pos = index;
                }
                index++;
            }
            return new Tuple<int, int>(min, pos);
        }

        [Fact]
        public void TupleTest1() { /**/

            // create a 3 element tuple called "x" that holds 3 integer pieces of related information
            // store values 1,2,3 in the created tuple.  It appears you do this at creation time
            var y = new Tuple<int, int, int>(1,2,3);
            // or you can just do
            var x = Tuple.Create(1, 2, 3);

            // create an array of tuples
            Tuple<string, double, int>[] scores =
                      { Tuple.Create("Jack", 78.8, 8),
                      Tuple.Create("Abbey", 92.1, 9),
                      Tuple.Create("Dave", 88.3, 9),
                      Tuple.Create("Sam", 91.7, 8),
                      Tuple.Create("Ed", 71.2, 5),
                      Tuple.Create("Penelope", 82.9, 8),
                      Tuple.Create("Linda", 99.0, 9),
                      Tuple.Create("Judith", 84.3, 9) };

            // pass the tuple to a function to find the min of the 3rd item
            (int min, int pos) = FindMinOf3rd(scores);
            Assert.Equal(5, min);
            Assert.Equal(4, pos);

            // sort a list of tuples ascending by the 2nd field in the tuple
            List<Tuple<int, string>> mylist = new List<Tuple<int, string>>();
            mylist.Add(new Tuple<int, string>(2, "foo"));
            mylist.Add(new Tuple<int, string>(1, "bar"));
            mylist.Add(new Tuple<int, string>(3, "qux"));
            mylist.Sort((a, b) => a.Item2.CompareTo(b.Item2));

            Assert.Equal(1, mylist.First().Item1);

        } /**/
    }
}