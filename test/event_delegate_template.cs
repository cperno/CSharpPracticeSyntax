// A delegate type represents references to methods with a particular parameter list and return type. 
//  Delegates make it possible to treat methods as entities that can be assigned to variables and passed as parameters. 
//  Delegates are similar to the concept of function pointers found in some other languages, 
//  but unlike function pointers, delegates are object-oriented and type-safe.
// A delegate lets you pass an algorithm (like a sort criteria) into another algorithm (like a sorting function)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpPracticeSyntax
{ 
    public class EventTests
    {
        static private int globalnum=0;
        // the subject being observed has a place where callbacks can be registered
        class SubjectBeingObserved
        {
            public event EventHandler<MyEventArgs>? SomethingHappened;

            // the subject being observed is responsible for calling invoke.
            // It is responsible for checking if there are any callbacks registered
            public void CauseSomething(int val) => OnSomethingHappened(new MyEventArgs() { val = val });

            protected virtual void OnSomethingHappened(MyEventArgs e)
            {
                EventHandler<MyEventArgs>? handler = SomethingHappened;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
            // an EventHandler has a specific signature
            public event EventHandler<MyEventArgs>? SomethingHappenedEvent;
        }

        public class MyEventArgs : EventArgs
        {
            public int val { get; set; }
        }

        class Observer
        {
            public void HandleEvent(object sender, EventArgs args)
            {
                // this will come in on the same thread that called Invoke
                // and will have this callstack which does not include the Invoke
                // Observer.HandleEvent...
 	            // SubjectBeingObserved.CauseSomething...
 	            // EventTest1()

                Console.WriteLine("Something happened to " + sender);
                EventTests.globalnum = 7;
            }
        }

        // show how to setup and fire an event
        [Fact]
        public void EventTest1()
        { /**/
            var subject = new SubjectBeingObserved();
            Observer observer = new Observer();

            // this is the subject adding a subscriber to itself, but you can imagine
            // having the observer call a method on the subject to add himself
            subject.SomethingHappened += observer.HandleEvent;

            subject.CauseSomething(7);
            Assert.Equal(7, EventTests.globalnum);
        }


        // declare a regular function
        private static int CompareLength(string left, string right) => left.Length.CompareTo(right.Length);

        //declare a delegate object using the Comparison class template that .NET gives us.
        // We choose to assign a function to the invocation list here but we also show how to do it later
        public static Comparison<string> comparator = CompareLength;

        [Fact]
        public void DelegateTest1()
        {
            // show how to pass a sorting criteria into a sorting function
            var slist = new List<string>();
            slist.Add("LooooongWord");
            slist.Add("ShortWord");

            // this is what sort does by default but we are doing to override to sort by length not content
            slist.Sort(Comparer<string>.Default);
            Assert.Equal(slist, new List<string>() { "LooooongWord", "ShortWord" });

            // if you didn't assign at declare time, assign the actual function to the invocation list here at runtime
            comparator += CompareLength;
            slist.Sort(comparator);

            Assert.Equal(slist, new List<string>() { "ShortWord", "LooooongWord" });
        }
    }
}