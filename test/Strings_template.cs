// building a string with interpolation
// parsing the string
// searching a string
// encoding and decoding a string

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace CSharpPracticeSyntax
{
    public class StringsTests
    {
        [Fact]
        public void StringLength()
        {
            string sourcestring="abcd";
            // get the number of characters in sourcestring
            int len = 0;
            len = sourcestring.Length;  /**/
            Assert.Equal(4, len);

            // verify the sourcestring does not have 0 chars in it
            bool has_zero_chars = false;
            has_zero_chars = String.IsNullOrEmpty(sourcestring); /**/
            Assert.False(has_zero_chars);
        }

        [Fact]
        public void StringReverse()
        {
            string sourcestring = "abcdef";
            string reversed = "";

            // for each character in the sourcestring, starting from the last char and going to beginning char
            for (int x = sourcestring.Length - 1; x >= 0; x--)
            {
                // add the character to the reversed string
                reversed += sourcestring[x];
            }

            Assert.Equal(@"fedcba", reversed);
        }

        [Fact]
        public void StringBuilding()
        {
            string sourcestring = "abc";
            string sourcestring2 = "xyz";

            // concatenate the 2 strings with a comma between them
            string name;
            name = sourcestring + "," + sourcestring2; /**/
            Assert.Equal("abc,xyz", name);

            var sb = new StringBuilder();
            sb.Append(sourcestring);
            sb.Append(",");
            sb.Append(sourcestring2);
            Assert.Equal("abc,xyz", name);

            // build a string by substututing in values
            int intval = 7;
            string s1;
            s1 = string.Format("the number is {0}", intval); /**/
            Assert.Equal("the number is 7", s1);
            string s2;
            s2 = $"the number is {intval}"; /**/
            Assert.Equal("the number is 7", s2);
        }

        [Fact]
        public void StringSearchAndReplace()
        {
            string sourcestring = "abc2def";

            // count the number of times the number 2 appears in sourcestring
            int numfound = 0;
            foreach (char c in sourcestring) /**/
            { /**/
                if (c == '2') /**/
                    numfound++; /**/
            } /**/

            //verify that it was found once 
            Assert.Equal(1, numfound);

            // return true if the letter a is found in sourcestring
            Int32 pos = -1;
            pos = sourcestring.IndexOf('a'); /**/
            Assert.NotEqual(-1, pos);

            // replace all t with w
            string replacetw = "this is a test string.";
            replacetw = replacetw.Replace('t', 'w');  /**/
            Assert.Equal("whis is a wesw swring.", replacetw);
        }

        [Fact]
        public void SubStrings()
        {
            string sourcestring = "abc";

            // make a copy into before
            string before = sourcestring;

            // start at pos 0 and return 1 char
            string firstchar = sourcestring.Substring(0, 1);/**/
            Assert.Equal("a", firstchar); 

            // start at pos 1 and go to end
            string restOfString = sourcestring.Substring(1);    /**/
            Assert.Equal("bc", restOfString);
        }

        [Fact]
        public void StringCompare()
        {
            string sourcestring = "abc";
            string sourcestring2 = "aBc";

            // compare string1 and 2 with case sensitive
            Assert.False(sourcestring.Equals(sourcestring2));

            // compare string1 and 2 with NOT case sensitive
            Assert.True(sourcestring.Equals(sourcestring2, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}

    