// there is no non public inheritance
// this is both inheritance and public/private and attributes instead of properties

using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticeSyntax
{
    class MyBaseClass
    { /**/
	    public void public1() { } /**/
	    protected void protected1() { } /**/
	    private void private1() { } /**/
    }; /**/

    // define a derived class MyPublicInheritanceClass that uses PUBLIC inheritance of the myobject base class
    // The derived class should have 3 methods each calling one of the public,protected,private methods in the myobject
    class MyPublicInheritanceClass : MyBaseClass {
	    public MyPublicInheritanceClass() { }
        public void MyPublicCallingPublic() { public1(); }
        public void MyPublicCallingProtected() { protected1(); }
        //this does not compile void MyPublicCallingPrivate() { private1(); }
    };

    // define an abstract base class called myabstractclass 
    // and give it a virtual function std::string getName() that returns the protected member var name.
    abstract class myabstractclass {
        public myabstractclass() { name =""; }
        public virtual string getName() { return (name); }
        private string name;
    };

    // define a mynameclass that public inherits from the abstract base class
    // show overriding the getName() virtual function using the override keyword
    class mynameclass : myabstractclass {
        public mynameclass() { thename = ""; }
        public override string getName()  { return (thename); }    // you don't have to use the override keyword
        private string thename;
    };
    // define an interface class and give it add and subtract methods
    interface myinterface
    {
        void add(int val);
        void subtract(int val);
    };

    // define a class myinteger that implements that interface
    class myinteger : myinterface
    {
        public void add(int val) { internal_val += val; }
        public void subtract(int val) { internal_val -= val; }
        private int internal_val;
    };

    partial class Program
    {
        static int classes_inheritance_main()
        { /**/
            int Warning_ThisCodingIsNotYetCompleted;/**/
            //create an object MyPublicInheritanceClass
            CSharpPracticeSyntax.MyPublicInheritanceClass pu = new CSharpPracticeSyntax.MyPublicInheritanceClass();
            // try calling each of the methods
            pu.MyPublicCallingPublic();
            pu.MyPublicCallingProtected();
            // try calling the base class public1 function.
            pu.public1();
            // pu.protected1(); this does not compile
            // pu.private1(); this does not compile

            // create an object of the class derived from your abstract class
            CSharpPracticeSyntax.mynameclass x = new CSharpPracticeSyntax.mynameclass();
            // call the getname in mynameclass
            string thename = x.getName();
            // you can't call the getname in myabstractclass with this pointer.  You have to use a base class pointer.
            //thename = x.myabstractclass::getName();

            // create an object of myinteger class that implemented the interface
            var i = new CSharpPracticeSyntax.myinteger();

            return (0); /**/
        }
    }
}