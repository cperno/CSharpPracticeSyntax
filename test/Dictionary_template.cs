using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeSyntax
{
    public class DictionaryTests
    {
        // implement a baseball team list as a map because no two players can have the same uniform number

        [Fact]
        public void DictionaryTest1()
        {
            // define a dictionary with the uniform number key and player name value 
            var d = new Dictionary<int, string>();

            // insert a 32, "john"
            d.Add(32, "john");

            // insert a 7 "rick"
            d.Add(7, "rick");

            // insert 9, "ted" using array brackets
            d[9] = "ted";

            // get the count of items in the map
            Assert.Equal(3, d.Count);

            // lookup by uniform number an item in the map that is not in there 
            string? playername;
            Assert.True(d.TryGetValue(32, out playername));
            Assert.Equal("john", playername);

            Assert.False(d.TryGetValue(99, out playername));
            Assert.Null(playername);

            // get the count of items in the map to prove it was not added
            Assert.Equal(3, d.Count);

            // get the name of the player wearing uniform number 32. This would throw an exception if not found.
            Assert.Equal("john", d[32]);

            // trade (remove) a player with uniform number 32
            d.Remove(32);
            Assert.Throws<KeyNotFoundException>(() => d[32]);

            // trade (remove) a player rick by name
            // we iterate through the dictionary because it is indexed on number not name
            foreach (var player in d)
            {
                if (player.Value == "rick")
                {
                    d.Remove(player.Key);
                    break;
                }
            }

            // get the count of items in the map
            Assert.Single(d);
        }
    }
}