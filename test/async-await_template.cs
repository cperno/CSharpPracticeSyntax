using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPracticeSyntax
{
    public class AsyncAwaitTests
    {
        public Task<int> MyAsyncFunction()
        {
            return Task.FromResult(7);
        }

        // we use async to *mark* a method as asynchronous
        [Fact]
        public async void AwaitAnAsyncFunction()
        {
            // with await, we can wait for an asynchronous operation in such a way that the original thread is not blocked
            var x = await MyAsyncFunction();
            Assert.Equal(7, x);
        }
    }
}