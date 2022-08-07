// example of serialize and deserialize using dotnet and json

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Newtonsoft;
using Newtonsoft.Json;

namespace CSharpPracticeSyntax
{
    public class JsonTests
    {
        public class MyJsonClass
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string? Summary { get; set; }
        }

        [Fact]
        public void JsonTest1()
        {
            var x = new MyJsonClass() { Date = DateTimeOffset.Now, TemperatureCelsius = 44, Summary = "abcd" };
            MyJsonClass? y;

            MemoryStream ms = new MemoryStream();
            string s  = System.Text.Json.JsonSerializer.Serialize(x);
            y = System.Text.Json.JsonSerializer.Deserialize<MyJsonClass>(s);
            Assert.NotNull(y);
            Assert.Equal(x.Date, y.Date);
            Assert.Equal(x.TemperatureCelsius, y.TemperatureCelsius);
            Assert.Equal(x.Summary, y.Summary);
        }

        [Fact]
        public async void JsonTest2()
        {
            var x = new MyJsonClass() { Date = DateTimeOffset.Now, TemperatureCelsius = 44, Summary = "abcd" };
            MyJsonClass? y;

            MemoryStream ms = new MemoryStream();
            // show the serializeAsync
            await System.Text.Json.JsonSerializer.SerializeAsync(ms,x);
            ms.Position = 0;
            y = await System.Text.Json.JsonSerializer.DeserializeAsync<MyJsonClass>(ms);
            Assert.NotNull(y);
            Assert.Equal(x.Date, y.Date);
            Assert.Equal(x.TemperatureCelsius, y.TemperatureCelsius);
            Assert.Equal(x.Summary, y.Summary);
        }
    }
}